using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; 

public class WindParameter : MonoBehaviour {

    public StudioEventEmitter windSound;
    Transform player;

    public float height;
    public float maxHeight = 500f; 


    private void Start()
    {
        windSound.SetParameter("Wind", 0f);

        GameObject playerGO = GameObject.FindWithTag("Player");

        player = playerGO.transform;
        height = player.position.y; 

    }

    private void Update()
    {
     
        height = player.position.y;
        float scaledHeight = height / maxHeight;

        windSound.SetParameter("Wind", scaledHeight);

 

    }


}
