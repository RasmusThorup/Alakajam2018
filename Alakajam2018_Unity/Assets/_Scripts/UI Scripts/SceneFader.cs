using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
                 

public class SceneFader : MonoBehaviour {

    public Image imgIn;
    public Image imgOut;
    //public Text text;
    public float t = 1f; 
    public AnimationCurve curve;
 

    public StudioEventEmitter fadeOutSound; 



	private void Start()
	{
        StartCoroutine(FadeIn());
	}


    public void FadeTo (string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            imgIn.color = new Color(imgOut.color.r, imgOut.color.g, imgOut.color.b, a);
           //text.color = new Color(text.color.r, text.color.g, text.color.b, a);
            yield return 0;

        }
        //fadeOutSound.Play();
        SceneManager.LoadSceneAsync(scene);
    }

    IEnumerator FadeIn()
    {
        //float t = 3f; 
        while (t > 0)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            imgIn.color = new Color(imgIn.color.r, imgIn.color.g, imgIn.color.b, a);
            //text.color = new Color(text.color.r, text.color.g, text.color.b, a);
            yield return 0;
        }
    }
}
