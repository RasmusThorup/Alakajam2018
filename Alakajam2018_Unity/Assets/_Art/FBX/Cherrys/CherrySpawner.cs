using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherrySpawner : MonoBehaviour {

    public GameObject[] cherryBombsToSpawn;

    public Transform playerTrans;

    public float yOffset = 16;

    [Header("Randomly Spawns Between")]
    public float spawnIntervalMin = 1;
    public float spawnIntervalMax = 5;

    public GameObject warningGo;

    public float warningTime = 1.5f;

    private float time;


    //public bool startBombing;

    public static bool bombingActive;

    void Start () {

        foreach (var cherry in cherryBombsToSpawn)
        {

            cherry.SetActive(false);
        }

        warningGo.SetActive(false);

    }
	

	void Update () {

        if (GameManager.instance.gameOver)
        {
            return;
        }

        if (playerTrans.position.y<100)
        {
            return;
        }
        
        if (bombingActive)
        {
            transform.position = new Vector3(transform.position.x, playerTrans.position.y + yOffset, transform.position.z);
            return;
        }

        transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y + yOffset, playerTrans.position.z);

        time -= Time.deltaTime;

        if (time <= 0)
        {
            StartCoroutine(SpawnCherryBomb());
            time = Random.Range(spawnIntervalMin, spawnIntervalMax);
        }
    }

    IEnumerator SpawnCherryBomb(){

        warningGo.SetActive(true);
        bombingActive = true;

        yield return new WaitForSeconds(warningTime);

        warningGo.SetActive(false);

        GameObject cherryGO = cherryBombsToSpawn[Random.Range(0, 1)];
        cherryGO.SetActive(true);
        cherryGO.transform.position = transform.position;


        yield return null;
    }
}
