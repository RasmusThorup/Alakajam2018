using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    private Transform player;

    [HideInInspector]
    public int currentScore;

    private int highScore;
    private int playerPos;

	void Start () 
    {
        player = GetComponent<GameManager>().player.transform;
        highScore = GetComponent<GameManager>().highScore;

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
        if (currentScore > highScore)
        {
            highScore = currentScore;
        }
    }
}
