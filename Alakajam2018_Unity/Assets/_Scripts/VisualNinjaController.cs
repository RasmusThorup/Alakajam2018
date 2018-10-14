using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualNinjaController : MonoBehaviour {

    public Transform NinjaMesh;
    public Rigidbody playerRigid;

    public float turnRate;

    Quaternion newRotation;

	// Use this for initialization
	void Start () {
		
	}

    void Update () {

        if (playerRigid.velocity.x > 0)
        {
            newRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (playerRigid.velocity.x < 0)
        {
            newRotation = Quaternion.Euler(0, -180, 0);
        }

        NinjaMesh.rotation =  Quaternion.RotateTowards(NinjaMesh.rotation, newRotation, turnRate * Time.unscaledDeltaTime);

        //NinjaMesh.localScale = new Vector3(1, 1* Mathf.Clamp(playerRigid.velocity.normalized.magnitude,.8f,1), 1);

    }

    public void NinjaSquat(float squatAmount){
        NinjaMesh.localScale = new Vector3(1, 1*squatAmount, 1);

    }
}
