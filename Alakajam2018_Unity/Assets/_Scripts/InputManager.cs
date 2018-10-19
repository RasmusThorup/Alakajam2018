using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public Vector2 playerAim;
    public float deadzone = .25f;
    public bool isJumping;
    bool jumpButtonUp;

    public bool jumpReleased;

    bool resetAim;

    float horizontal;
    float vertical;

    public float keyboardAimRate;

    void Update()
    {

        if (GameManager.instance.gameOver)
            return;

        if (Input.GetJoystickNames().Length > 0)
        {
            //There is a joystick coneccted
            playerAim = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (playerAim.magnitude < deadzone)
                playerAim = Vector2.zero;

        }else
        {
            //Only Keyboard

            if (resetAim)
            {
                horizontal = 0;
                vertical = 1;
                resetAim = false;
            }


            if (Input.GetAxisRaw("Horizontal")<0)
            {
                //Left
                horizontal -= Time.deltaTime* keyboardAimRate;

                if (horizontal>0)
                {
                    //Aim has been towards right and is going back
                    vertical += Time.deltaTime* keyboardAimRate;
                } else
                {
                    vertical -= Time.deltaTime * keyboardAimRate;
                }

            }
            else if(Input.GetAxisRaw("Horizontal") >0)
            {
                //Right 
                horizontal += Time.deltaTime* keyboardAimRate;
                if (horizontal < 0)
                {
                    //Aim has been towards right and is going back
                    vertical += Time.deltaTime * keyboardAimRate;
                }
                else
                {
                    vertical -= Time.deltaTime * keyboardAimRate;
                }
            
            }

            playerAim = new Vector2(horizontal, vertical);

        }


        isJumping = Input.GetButton("Jump");


        //Button is down
        if (isJumping)
        {
            jumpReleased = false;
        }
        else
        {
            jumpReleased = true;
            resetAim = true;
        }

    }
}
