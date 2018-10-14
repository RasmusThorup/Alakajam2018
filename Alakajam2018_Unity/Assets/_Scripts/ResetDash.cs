using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDash : MonoBehaviour
{

    PlayerController playerController;
    Rigidbody playerRigid;

    NinjaVisualController ninjaVisual;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        playerRigid = player.GetComponent<Rigidbody>();

        ninjaVisual = FindObjectOfType<NinjaVisualController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            if (playerController.firstDashHappend)
            {
                GameManager.instance.GameOver();
            }else
            {
                //Start Player ability to aim
                playerController.canAim = true;


                //Stopping Player momentum
                playerRigid.velocity = Vector3.zero;
                playerController.gravityAmount = 0;
                playerRigid.useGravity = false;

                ninjaVisual.ChangeNinjaPose(0);

                playerController.LandedOnLeaf();

                if (!ninjaVisual.ninjaVisualEnabled)
                {
                    ninjaVisual.EnableStartingPose();
                }
            }



    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.CompareTag("Player"))
    //    {
    //        //Start Player ability to aim
    //        playerController.canAim = true;

    //        //Reset dash
    //        playerController.ResetDashAmount();


    //        //Stopping Player momentum
    //        playerRigid.velocity = Vector3.zero;
    //        playerController.gravityAmount = 0;
    //        playerRigid.useGravity = false;
    //    }
    //}
}
