using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaEyeController : MonoBehaviour {


    public GameObject eyes;


    private void OnEnable()
    {

        StartCoroutine(Blinking());
    }

    IEnumerator Blinking()
    {
        float flickerSpeed = .25f;
        int randomizer = 0;
        while (true)
        {
            if (randomizer == 0)
            {
                eyes.SetActive(false);

            }
            else eyes.SetActive(true);
            randomizer = Random.Range(0, 6);

            yield return new WaitForSeconds(flickerSpeed);
        }
    }

    private void OnDisable()
    {
        StopCoroutine(Blinking());
    }
}
