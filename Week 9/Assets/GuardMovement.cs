using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour
{
    public GameObject[] patrolSpots;
    public GameObject player;
    private Transform target;
    float dist;
    
    int spotLoc;
    public static bool isChasing;
    void Start()
    {
        spotLoc = 0;
        isChasing = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 2 * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolSpots[spotLoc].transform.position, 2 * Time.deltaTime);

            dist = Vector2.Distance(transform.position, patrolSpots[spotLoc].transform.position);
            if (dist <= 0)
            {
                spotLoc++;
                if (spotLoc == 4)
                {
                    spotLoc = 0;
                }
            }
        }
    }
}
