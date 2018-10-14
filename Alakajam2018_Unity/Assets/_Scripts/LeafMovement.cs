using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafMovement : MonoBehaviour {

    float fallingSpeed;

    public Vector2 fallingSpeedMinMax;

    public float leafXPosition;

    float distanceAmount;

    public Animator animator;

    public Transform floatVisual;

    float xOffset;

    private void OnEnable()
    {
        fallingSpeed = Random.Range(fallingSpeedMinMax.x,fallingSpeedMinMax.y);
        distanceAmount = Random.Range(.01f, .5f);
        animator.speed = Random.Range(.3f, 1);

        xOffset = transform.position.x;
    }


    void Update () {

        transform.position += Vector3.down * fallingSpeed * Time.deltaTime;

        floatVisual.position = new Vector3 ((leafXPosition*distanceAmount)+ xOffset, floatVisual.position.y, floatVisual.position.z);
    }


}
