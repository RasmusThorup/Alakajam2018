using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryBomb : MonoBehaviour {

    public float fallingSpeed = 15f;

    public PlayerController playerController;
    public Rigidbody playerRigid;

    // Use this for initialization
    void Start () {
        GameObject player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        playerRigid = player.GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.down * fallingSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.gameOver)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            playerController.enabled = false;

            //Stopping Player momentum
            playerRigid.velocity = Vector3.zero;
            playerRigid.useGravity = true;

        }
        if (other.CompareTag("Despawner"))
        {
            gameObject.SetActive(false);
        }
    }
}
