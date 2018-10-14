using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    private Transform player;

    [HideInInspector]
    public float currentScore;

    private float playerPos;

    public TMP_Text points;

	void Start () 
    {
        player = GetComponent<GameManager>().player.transform;
	}
	
	void FixedUpdate () 
    {
        playerPos = player.transform.position.y;

        //incase player falls down, keeps points
        if (playerPos * 100 >= currentScore)
        {
            currentScore = playerPos * 100;
        }

        //is current score higher than highscore?
        if (currentScore > GameManager.highScore)
        {
            GameManager.highScore = currentScore;
        }

        points.text = currentScore.ToString("F0");
    }
}
