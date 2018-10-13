using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform player;
    private float distanceToPlayer;
    private float playerYPos;
    public int maxDistance = 15;

    private void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<Transform>();
    }

    void Update()
    {
        playerYPos = player.transform.position.y;
        distanceToPlayer = playerYPos - transform.position.y;
        if (distanceToPlayer > maxDistance)
        {
            transform.position = new Vector3(0, player.transform.position.y - maxDistance, 0);
        }
    }
}
