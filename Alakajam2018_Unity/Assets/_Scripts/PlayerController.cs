﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    InputManager input;
    Rigidbody playerRigidbody;

    public Transform aim;
    bool currentlyAiming;

    public float jumpingForce;
    public float jumpingForceTimer = 1;
    public Vector2 jumpingForceMinMax;

    public float gravityAmount;
    float initGravityAmount;

    [Range(0,1)]
    public float timeSlowdown;

    public int numberOfDashes;
    int initNumberOfDashes;

    public bool canAim = true;

    public Slider canonAimSlider;

    bool JumpButtonReleased;

    bool doOnceDashes;

    Vector2 playerAim;

    void Start () {

        input = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();

        //Setting some things
        canAim = true;
        doOnceDashes = true;

        if (numberOfDashes!=0)
        {
            numberOfDashes += 1;
            initNumberOfDashes = numberOfDashes;
        }

        //Saving Init Gravity
        initGravityAmount = gravityAmount;

        //Setting min Max on slider
        canonAimSlider.minValue = jumpingForceMinMax.x;
        canonAimSlider.maxValue = jumpingForceMinMax.y;

        jumpingForce = jumpingForceMinMax.x;

    }

    private void FixedUpdate()
    {
        if (canAim && input.isJumping && jumpingForce<jumpingForceMinMax.y && JumpButtonReleased)
        {
            //player aim
            PlayerAiming();
        }
        else if (currentlyAiming)
        {
            //player jump force added
            PlayerCanon();
        }
        else if (input.isJumping)
        {
            //player still holding jump down after jumping

        }else
        {
            //Player let go
            JumpButtonReleased = true;

        }



        //Handle in air Dashes
        if (numberOfDashes > 0 && input.isJumping)
        {
            canAim = true;

            if (doOnceDashes)
            {
                numberOfDashes -= 1;
                doOnceDashes = false;
            }
        }

        //Add player Gravity
        PlayerGravity();

    }

    void PlayerAiming(){
        currentlyAiming = true;
        //Setting the aim art
        aim.eulerAngles = new Vector3(0, 0, -(Mathf.Atan2(input.playerAim.x, input.playerAim.y) * 180 / Mathf.PI));

        //Building Jump Force
        jumpingForce += jumpingForceTimer;

        //Setting UI canon aim slider
        canonAimSlider.value = jumpingForce;

        //Setting bullet time
        Time.timeScale = timeSlowdown;
        Time.fixedDeltaTime = .02f * Time.timeScale;
    }

    void PlayerCanon(){
        // Player is jumping
        JumpButtonReleased = false;

        //Stopping all other forces
        playerRigidbody.velocity = Vector3.zero;

        //sætter det så spilleren ikke bare står stille hvis spilleren ikke sigter
        if (input.playerAim == Vector2.zero)
        {
            playerAim = Vector2.up;
        }else
        {
            playerAim = input.playerAim;
        }

        playerRigidbody.AddForce(playerAim * Mathf.Clamp(jumpingForce, jumpingForceMinMax.x, jumpingForceMinMax.y), ForceMode.VelocityChange);



        //Reset variables
        jumpingForce = jumpingForceMinMax.x;
        gravityAmount = initGravityAmount;
        Time.timeScale = 1;
        canonAimSlider.value = jumpingForce;
        currentlyAiming = false;
        canAim = false;
        doOnceDashes = true;
    }


    public void PlayerGravity(){
        playerRigidbody.AddForce(Vector3.down * gravityAmount, ForceMode.Acceleration);
    }

    public void ResetDashAmount(){
        numberOfDashes = initNumberOfDashes;
    }
}
