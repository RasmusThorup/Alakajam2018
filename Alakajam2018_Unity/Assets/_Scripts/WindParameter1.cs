using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; 

public class WindParameter : MonoBehaviour {

    public StudioEventEmitter windSound;
    public Transform player;

    public float height;
    public float maxHeight = 500f; 


    private void Start()
    {
        windSound.SetParameter("Wind", 0f);

        height = player.transform.position.y; 

    }

    private void Update()
    {
     
        height = player.transform.position.y;
        float scaledHeight = height / maxHeight;

        windSound.SetParameter("Wind", scaledHeight); 

 

    }


}
