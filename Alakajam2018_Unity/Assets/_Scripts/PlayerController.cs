using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using FMODUnity;

public class PlayerController : MonoBehaviour {

    InputManager input;
    Rigidbody playerRigidbody;

    public NinjaVisualController ninjaVisualController;

    public Transform aim;
    bool currentlyAiming;

    float jumpingForce;
    public float jumpingForceTimer = 1;
    public Vector2 jumpingForceMinMax;

    public float gravityAmount;
    float initGravityAmount;

    [Range(0,1)]
    public float timeSlowdown;

    public int numberOfDashes;
    int initNumberOfDashes;

    public float airControlSpeed;

    [HideInInspector]
    public bool canAim = true;

    public Slider canonAimSlider;

    bool JumpButtonReleased;

    bool doOnceDashes;

    Vector2 playerAim;


    public bool firstDashHappend;

    [Header("FMOD Refs")]
    public StudioEventEmitter jumpCharging;

    public StudioEventEmitter chargeSnapshot; 

    [Header("Events FOR STUFF")]
    public UnityEvent playerCanonShoot;
    public UnityEvent playerLandedOnLeaf;




    void Start () {

        input = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();

        //Setting some things
        //canAim = true;
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


        firstDashHappend = false;
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.gameOver)
            return;
        

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

        if (!canAim)
        {
            AirControl();
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

        if (!jumpCharging.IsPlaying())
        {
            chargeSnapshot.Play();
        }
        currentlyAiming = true;

        //Setting the aim art
        float aimRotation = -(Mathf.Atan2(input.playerAim.x, input.playerAim.y) * 180 / Mathf.PI);

        aim.eulerAngles = new Vector3(0, 0, aimRotation);

        //Building Jump Force
        jumpingForce += jumpingForceTimer;


        //Setting UI canon aim slider
        canonAimSlider.value = jumpingForce;

        //Setting bullet time

        Time.timeScale = timeSlowdown;
        Time.fixedDeltaTime = .02f * Time.timeScale;



        //FMOD Charge
        if (!jumpCharging.IsPlaying())
        {
            jumpCharging.Play();
        }

        jumpCharging.SetParameter("ChargeUp", (jumpingForce-jumpingForceMinMax.x / (jumpingForceMinMax.y - jumpingForceMinMax.x)));
    }

    void PlayerCanon(){
        chargeSnapshot.Stop();

        firstDashHappend = true;

        // Player is jumping
        JumpButtonReleased = false;

        ninjaVisualController.ChangeNinjaPose(1);

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


        //FMOD
        if (jumpCharging.IsPlaying())
        {
            jumpCharging.Stop();
        }

        playerCanonShoot.Invoke();

    }

    public void LandedOnLeaf(){
        playerLandedOnLeaf.Invoke();
    }

    void AirControl(){

        playerRigidbody.AddForce(new Vector3(input.playerAim.x, 0, 0) * airControlSpeed, ForceMode.Acceleration);
    }

    public void PlayerGravity(){
        playerRigidbody.AddForce(Vector3.down * gravityAmount, ForceMode.Acceleration);
    }

    public void ResetDashAmount(){
        numberOfDashes = initNumberOfDashes;
    }
}
