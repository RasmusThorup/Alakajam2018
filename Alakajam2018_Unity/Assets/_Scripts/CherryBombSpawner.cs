using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryBombSpawner : MonoBehaviour {

    public Transform playerPosition;

    public GameObject[] cherryBombs;

    public GameObject WarningUI;

    public float warningTime;

    [Header("Spawn Interval Ting")]
    public float spawnIntervalMin = 1;
    public float spawnIntervalMax = 5;

    public bool startBombing;
    public static bool bombingActive;

    private float time;

    private void Start()
    {
        time = Random.Range(spawnIntervalMin, spawnIntervalMax);

        WarningUI.SetActive(false);

        foreach (var cherry in cherryBombs)
        {
            GameObject obj = Instantiate(cherry,transform);
            obj.SetActive(false);
        }

        bombingActive = false;
    }

    private void Update()
    {
        if (GameManager.instance.gameOver)
        {
            return;
        }

        if (!startBombing)
        {
            return;
        }

        if (bombingActive)
        {
            transform.position = new Vector3(transform.position.x, playerPosition.position.y+16, transform.position.z);
            return;
        }

        transform.position = new Vector3(playerPosition.position.x, playerPosition.position.y + 16, playerPosition.position.z);

        time -= Time.deltaTime;

        if (time <= 0)
        {
            StartCoroutine(SpawnCherryBomb());
            time = Random.Range(spawnIntervalMin, spawnIntervalMax);
        }
    }


    IEnumerator SpawnCherryBomb(){
        bombingActive = true;
        WarningUI.SetActive(true);

        yield return new WaitForSeconds(warningTime);

        WarningUI.SetActive(false);

        GameObject GO = transform.GetChild(Random.Range(0, 1)).gameObject;

        GO.SetActive(true);
        GO.transform.position = transform.position;

        yield return null;
    }

}
