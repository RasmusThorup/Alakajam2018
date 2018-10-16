using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public Vector2 playerAim;
    public float deadzone = .25f;
    public bool isJumping;
    bool jumpButtonUp;

    public bool jumpReleased;

    void Update()
    {

        if (GameManager.instance.gameOver)
            return;

        playerAim = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (playerAim.magnitude < deadzone)
            playerAim = Vector2.zero;

        isJumping = Input.GetButton("Jump");


        //Button is down
        if (isJumping)
        {
            jumpReleased = false;
        }
        else
        {
            jumpReleased = true;
        }

    }
}
