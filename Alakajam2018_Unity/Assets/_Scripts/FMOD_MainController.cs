using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class FMOD_MainController : MonoBehaviour {

    public PlayerController playerController;
    public Rigidbody playerRigid;

    [Header("FmodRefs")]
    public StudioEventEmitter windEvent;
    public float maxVelocitySpeed;

    private void FixedUpdate()
    {
        print(playerRigid.velocity.magnitude);
        windEvent.SetParameter("Velocity", playerRigid.velocity.magnitude / maxVelocitySpeed);
    }

}
