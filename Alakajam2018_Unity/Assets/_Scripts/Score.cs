using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    private Transform player;

    [HideInInspector]
    public int currentScore;

    private int playerPos;

    public TMP_Text points;

	void Start () 
    {
        player = GetComponent<GameManager>().player.transform;
	}
	
	void FixedUpdate () 
    {
        playerPos = (int)player.transform.position.y;

        //incase player falls down, keeps points
        if (playerPos >= currentScore)
        {
            currentScore = playerPos;
        }

        //is current score higher than highscore?
        if (currentScore > GameManager.highScore)
        {
            GameManager.highScore = currentScore;
        }

        points.text = currentScore.ToString();
        Debug.Log(GameManager.highScore);
    }
}
