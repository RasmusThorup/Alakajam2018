using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class GameManager : MonoBehaviour {

    //Instance af selve gamemanager
    public static GameManager instance;

    public GameObject player;

    public GameObject gameOverUI;

    public StudioEventEmitter deadSound;

   

    [SerializeField]
    public float score;
    [SerializeField]
    public static float highScore;

    public static int currentLeafHashCode;

    public bool gameOver;

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

        gameOver = false;
    }

    void Start()
    {
        LockMouse();
    }



    public void GameOver()
    {
        gameOver = true;

        Time.timeScale = 1;

        gameOverUI.SetActive(true);

        player.SetActive(false);

        if (!deadSound.IsPlaying())
        {
            deadSound.Play(); 

        }
    }

    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
