using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FMODUnity;



public class OnClickSound : MonoBehaviour {


    public StudioEventEmitter onClick; 


    public void PlaySoundOnClick()
    {
        onClick.Play(); 
    }


}
