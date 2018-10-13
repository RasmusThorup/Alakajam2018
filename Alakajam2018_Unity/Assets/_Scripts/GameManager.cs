using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //Instance af selve gamemanager
    public static GameManager instance;

    public int playerLives;

    public float score;

    public int highScore;

    public GameObject player;

    private GameOverUI gameOverUI;





    bool isGameOver;
    bool gameHasStarted;

    private void Awake()
    {
        //If the variable instance has not be initialized, set it equal to this
        //GameManager script...
        if (instance == null)
            instance = this;
        //...Otherwise, if there already is a GameManager and it isn't this, destroy this
        //(there can only be one GameManager)
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        gameOverUI = GetComponent<GameOverUI>();

        LockMouse();
    }


    public bool IsActiveGame()
    {
        return gameHasStarted && !isGameOver;
    }

    public void GameOver()
    {
        gameOverUI.gameObject.SetActive(true);
    }

    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
