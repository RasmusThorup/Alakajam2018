using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafSpawner : MonoBehaviour {

    [Header("Prefab to Spawn")]
   // public GameObject prefab;

    [Header("Randomly Spawns Between")]
    public float spawnIntervalMin = 1;
    public float spawnIntervalMax = 5;

    [Header("Spawn Prefab With Offset")]
    public Vector3 spawnOffset;

    private float time;

    private void Start()
    {
        time = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    private void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            SpawnLeaf();
            time = Random.Range(spawnIntervalMin, spawnIntervalMax);
        }
    }


    void SpawnLeaf ()
    {

        GameObject obj = ObjectPoolController.current.GetPooledObject();

        if (obj == null) return;
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);

    }
}

