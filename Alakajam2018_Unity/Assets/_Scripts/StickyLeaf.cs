using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyLeaf : MonoBehaviour {


    PlayerController playerController;
    Rigidbody playerRigid;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        playerRigid = player.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
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
        }
    }
}
