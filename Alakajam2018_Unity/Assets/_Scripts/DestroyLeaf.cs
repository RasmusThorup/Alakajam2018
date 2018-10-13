using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLeaf : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Despawner"))
        {
            gameObject.SetActive(false);
        }


    }
}
