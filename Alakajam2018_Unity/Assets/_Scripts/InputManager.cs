using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public Vector2 playerAim;
    public float deadzone = .25f;
    public bool isJumping;

	void Update () {

        playerAim = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (playerAim.magnitude < deadzone)
            playerAim = Vector2.zero;

        isJumping = Input.GetButton("Jump");



    }
}
