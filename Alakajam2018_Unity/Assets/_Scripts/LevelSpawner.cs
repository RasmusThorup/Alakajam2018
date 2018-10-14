using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour {

    public static List<GameObject> levels = new List<GameObject>();
    private SpawnLevel spawnLevel;
    //private int maxLevels = 2;

	void Start () 
    {
        spawnLevel = GetComponentInParent<SpawnLevel>();
	}

    public void AddToList() //add new level to list
    {
        
        if (levels.Contains(gameObject) == false) //hvis den statiske liste ikke indeholder dette component, så tilføj det til listen.
        {
            levels.Add(gameObject);
            //CheckSpawnedCount();
            spawnLevel.LevelSpawn(transform);//spawn level
        }
    }

    //void CheckSpawnedCount()//destroy oldest level
    //{
    //    if (levels.Count > maxLevels)
    //    {
    //        GameObject firstAdded = levels[0];
    //        levels.RemoveAt(0);
    //        Destroy(firstAdded.gameObject);
    //    }
    //}
}
