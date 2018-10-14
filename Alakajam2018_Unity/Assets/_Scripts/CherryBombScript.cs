using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryBombScript : MonoBehaviour {


    public float fallingSpeed;

    PlayerController playerController;
    Collider playerCollider;
    Rigidbody playerRigid;

	void Start () {

        GameObject player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        playerRigid = player.GetComponent<Rigidbody>();
        playerCollider = player.GetComponent<Collider>();

    }

    void Update () {
        transform.position += Vector3.down * fallingSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            //Kill Player
            playerController.enabled = false;

            playerRigid.velocity = Vector3.zero;
            playerRigid.useGravity = true;
        }

        if (other.CompareTag("Despawner")){
            gameObject.SetActive(false);
        }

    }



    private void OnDisable()
    {
        CherryBombSpawner.bombingActive = false;
    }
}
