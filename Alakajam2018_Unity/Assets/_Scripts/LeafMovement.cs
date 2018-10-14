using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafMovement : MonoBehaviour {

    float fallingSpeed;

    public Vector2 fallingSpeedMinMax; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += Vector3.down * fallingSpeed * Time.deltaTime;

	}

    private void OnEnable()
    {
        fallingSpeed = Random.Range(fallingSpeedMinMax.x,fallingSpeedMinMax.y);
    }

}
