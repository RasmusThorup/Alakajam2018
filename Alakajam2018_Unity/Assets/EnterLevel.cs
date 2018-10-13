using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour {

    private LevelSpawner levelSpawner;

    private void Start()
    {
        levelSpawner = GetComponentInParent<LevelSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelSpawner.AddToList();
        }
    }
}
