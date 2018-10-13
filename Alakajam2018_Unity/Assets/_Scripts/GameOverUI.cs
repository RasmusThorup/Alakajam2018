using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour {

    private SceneFader sceneFader;
    public TMP_Text gameOverPoints;
    private Score score;
    public string menu = "Menu";
    public string retry = "Game";


    private void Start()
    {
        score = GetComponent<Score>();
        sceneFader = GetComponent<SceneFader>();
    }
    void Update () 
    {
        gameOverPoints.text = score.currentScore.ToString();
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
