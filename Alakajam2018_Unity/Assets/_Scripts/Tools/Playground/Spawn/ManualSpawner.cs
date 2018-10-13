using UnityEngine;

public class ManualSpawner : MonoBehaviour
{
    [Header("Prefab to Spawn")]
    public GameObject prefab;

    [Header("Spawn Prefab With Offset")]
    public Vector3 spawnOffset;

    [Space]
    public bool spawnAsChild;

    public void Spawn()
    {
        GameObject go = Instantiate(prefab, transform.position + spawnOffset, Quaternion.identity);
        if (spawnAsChild)
        {
            go.transform.SetParent(transform);
        }
    }
}