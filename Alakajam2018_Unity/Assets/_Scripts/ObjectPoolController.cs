using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolController : MonoBehaviour {



    public static ObjectPoolController current;

    public GameObject pooledObject;
    public int pooledAmount = 20;
    public bool willGrow;

    List<GameObject> pooledObjects;


    private void Awake()
    {
        current = this;
    }
    private void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj); 
        }
    }


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj; 
        }

        return null; 


    }









}
