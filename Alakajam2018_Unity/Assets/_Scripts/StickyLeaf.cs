using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyLeaf : MonoBehaviour {


    PlayerController playerController;
    Rigidbody playerRigid;
    public Collider leafCollider;

    NinjaVisualController ninjaVisual;
    int ownHashCode;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        playerRigid = player.GetComponent<Rigidbody>();

        ninjaVisual = FindObjectOfType<NinjaVisualController>();
        ownHashCode = GetHashCode();
    }

    private void OnEnable()
    {
        leafCollider.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.instance.gameOver)
        {
            return;
        }
        if (collision.collider.CompareTag("Player"))
        {
            //Start Player ability to aim
            playerController.canAim = true;

            //Reset dash
            playerController.ResetDashAmount();


            //Stopping Player momentum
            playerRigid.velocity = Vector3.zero;
            playerController.gravityAmount = 0;
            playerRigid.useGravity = false;

            leafCollider.enabled = false;

            playerController.LandedOnLeaf();

            if (collision.contacts[0].normal.y<0) // negative is up
            {
                ninjaVisual.ChangeNinjaPose(0);
            }else
            {
                ninjaVisual.ChangeNinjaPose(2);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.gameOver)
        {
            return;
        }
        if (other.CompareTag("Player"))
        {
            if (GameManager.currentLeafHashCode != 0)
            {
                leafCollider.enabled = false;
                return;
            }

            GameManager.currentLeafHashCode = ownHashCode;

            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (GameManager.instance.gameOver)
        {
            return;
        }
        if (other.CompareTag("Player"))
        {

            if (GameManager.currentLeafHashCode != ownHashCode)
            {
                leafCollider.enabled = true;
                return;
            }

            GameManager.currentLeafHashCode = 0;

            other.transform.parent = null;

            leafCollider.enabled = true;
        }
    }
}
