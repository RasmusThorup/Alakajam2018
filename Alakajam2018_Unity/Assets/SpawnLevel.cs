using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour {

    public GameObject levelFrame;
    public Vector3 spawnOffset;

    public void LevelSpawn(Transform pos)
    {
        GameObject go = Instantiate(levelFrame, pos.position + spawnOffset, Quaternion.identity, transform) as GameObject;
    }
}
