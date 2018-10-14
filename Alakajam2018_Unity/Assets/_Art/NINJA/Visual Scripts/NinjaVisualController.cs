using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NinjaVisualController : MonoBehaviour {

    public UnityEvent changePoseEvent;

   public GameObject[] NinjaPoses; //0 Standing, 1 = flying, 2 = holding

    public Rigidbody playerRigid;

    private void Start()
    {
        foreach (var pose in NinjaPoses)
        {
            pose.SetActive(false);
        }


        NinjaPoses[0].SetActive(true);
    }

    private void Update()
    {
        if (NinjaPoses[1].activeSelf)
        {
            //Change ninja rotation

            NinjaPoses[1].transform.rotation = Quaternion.LookRotation(-playerRigid.velocity, Vector3.up);
        }
    }

    public void ChangeNinjaPose(int poseNumber){
        foreach (var pose in NinjaPoses)
        {
            pose.SetActive(false);
        }

        NinjaPoses[poseNumber].SetActive(true);


        changePoseEvent.Invoke();

    }
}
