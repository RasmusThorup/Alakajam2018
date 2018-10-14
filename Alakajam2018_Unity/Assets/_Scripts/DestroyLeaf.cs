using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLeaf : MonoBehaviour {

    public Transform parent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Despawner"))
        {
            parent.gameObject.SetActive(false);
        }
    }
}
