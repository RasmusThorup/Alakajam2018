using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour {

    private SceneFader sceneFader;
    public string scene = "Game";
    public TMP_Text highestscore;

    void Start () 
    {
        sceneFader = GetComponent<SceneFader>();
	}

    private void Update()
    {
        SetHighScore();
    }

    public void PlayGame()
    {
        sceneFader.FadeTo(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }

    void SetHighScore()
    {
        highestscore.text = GameManager.highScore.ToString("F0");
    }

    
}
