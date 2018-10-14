using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnDisable : MonoBehaviour {

    private void OnDisable()
    {
        if (!GameManager.instance.gameOver)
        {

            GameManager.instance.GameOver();
        }
    }
}
