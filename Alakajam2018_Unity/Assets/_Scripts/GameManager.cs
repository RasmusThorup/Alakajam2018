using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //Instance af selve gamemanager
    public static GameManager instance;

    public GameObject player;

    public GameObject gameOverUI;

    [SerializeField]
    public float score;
    [SerializeField]
    public static int highScore;

    public static int currentLeafHashCode;

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
        LockMouse();
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
