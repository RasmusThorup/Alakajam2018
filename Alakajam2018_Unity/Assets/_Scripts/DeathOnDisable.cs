using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnDisable : MonoBehaviour {

    private void OnDisable()
    {
        GameManager.instance.GameOver();
    }
}
