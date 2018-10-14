using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour {

    public SceneFader sceneFader;
    public TMP_Text gameOverPoints;
    public Score score;
    public string menu = "Menu";
    public string retry = "Game";


    private void Start()
    {
        //sceneFader = GetComponent<SceneFader>();
    }
    void Update () 
    {
        gameOverPoints.text = score.currentScore.ToString("F0");
	}

    public void Retry()
    {
        sceneFader.FadeTo(retry);
    }

    public void GoToMenu()
    {
        sceneFader.FadeTo(menu);
    }
}
