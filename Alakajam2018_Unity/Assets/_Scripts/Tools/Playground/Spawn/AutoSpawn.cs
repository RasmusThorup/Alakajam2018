using UnityEngine;

public class AutoSpawn : MonoBehaviour
{
    [Header("Prefab to Spawn")]
    public GameObject prefab;

    [Header("Randomly Spawns Between")]
    public float spawnIntervalMin = 1;
    public float spawnIntervalMax = 5;

    [Header("Spawn Prefab With Offset")]
    public Vector3 spawnOffset;

    [Space]
    public bool spawnAsChild;

    private float time;

    private void Start()
    {
        time = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    private void Update()
    {
        time -= Time.deltaTime;

        if(time <= 0)
        {
            GameObject go = Instantiate(prefab, transform.position + spawnOffset, Quaternion.identity);
            if(spawnAsChild)
            {
                go.transform.SetParent(transform);
            }

            time = Random.Range(spawnIntervalMin, spawnIntervalMax);
        }
    }
}