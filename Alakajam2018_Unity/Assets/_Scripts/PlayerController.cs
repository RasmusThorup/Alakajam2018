using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    InputManager input;
    Rigidbody playerRigidbody;

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

    public bool canAim = true;


    bool doOnce;

	void Start () {
        input = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();

        //Setting some things
        canAim = true;
        doOnce = true;

        if (numberOfDashes!=0)
        {
            numberOfDashes += 1;
            initNumberOfDashes = numberOfDashes;
        }

        initGravityAmount = gravityAmount;

    }
	
	void Update () {
		
	}

    private void FixedUpdate()
    {

        if (canAim && input.isJumping)
        {
            PlayerAiming();
        }
        else if (currentlyAiming)
        {
            PlayerKanon();
        }
        else
        {
            //Player is in the air sorta..
        }

        //Handle Dashes
        if (numberOfDashes > 0 && input.isJumping)
        {
            canAim = true;

            if (doOnce)
            {
                numberOfDashes -= 1;
                doOnce = false;
            }
        }

        //Add player Gravity
        PlayerGravity();

    }

    void PlayerAiming(){
        currentlyAiming = true;
        //Setting the aim art
        aim.eulerAngles = new Vector3(0, 0, -(Mathf.Atan2(input.playerAim.x, input.playerAim.y) * 180 / Mathf.PI));

        jumpingForce += jumpingForceTimer;

        Time.timeScale = timeSlowdown;
        Time.fixedDeltaTime = .02f * Time.timeScale;
    }

    void PlayerKanon(){
        // Player released button and is jumping
        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.AddForce(input.playerAim * Mathf.Clamp(jumpingForce, jumpingForceMinMax.x, jumpingForceMinMax.y), ForceMode.VelocityChange);
        jumpingForce = 0;



        //Reset variables
        gravityAmount = initGravityAmount;
        Time.timeScale = 1;

        currentlyAiming = false;
        canAim = false;
        doOnce = true;
    }


    public void PlayerGravity(){
        playerRigidbody.AddForce(Vector3.down * gravityAmount, ForceMode.Acceleration);
    }

    public void ResetDashAmount(){
        numberOfDashes = initNumberOfDashes;
    }
}
