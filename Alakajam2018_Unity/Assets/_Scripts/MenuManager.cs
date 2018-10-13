using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour {

    private SceneFader sceneFader;
    public string scene = "Game";
    private GameManager gameManager;
    public TMP_Text highestscore;

    void Start () 
    {
        sceneFader = GetComponent<SceneFader>();
        gameManager = GetComponent<GameManager>();
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
        highestscore.text = gameManager.highScore.ToString();
    }

    
}
