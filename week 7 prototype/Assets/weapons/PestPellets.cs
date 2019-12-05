using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestPellets : MonoBehaviour
{
    float p1Distance;
    float p2Distance;
    float distanceCompare;

    float timer;

    Transform target;
    Transform target2;

    bool followPlayer;
    bool followPlayer2;

    bool countDown;
    void Start()
    {
        timer = 2f;

        target = GameObject.Find("Polygon").transform;
        target2 = GameObject.Find("Polygon (1)").transform;

        countDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 14 || transform.position.x <= -14)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.y >= 10 || transform.position.y <= -10)
        {
            Destroy(this.gameObject);
        }

        p1Distance = Vector2.Distance(target.transform.position, transform.position);
        p2Distance = Vector2.Distance(target2.transform.position, transform.position);

        if ((Mathf.Abs(p1Distance) - Mathf.Abs(p2Distance)) <= 0)
        {
            followPlayer = true;
            followPlayer2 = false;
        }
        else
        {
            followPlayer = false;
            followPlayer2 = true;
        }

        if (followPlayer == true && Mathf.Abs(p1Distance) <= 3f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, 3f * Time.deltaTime);
        }

        if (followPlayer2 == true && Mathf.Abs(p2Distance) <= 3f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target2.position, 3f * Time.deltaTime);
        }

        if (countDown == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.gameObject.name == "Polygon")
    //    {
    //        followPlayer = true;
    //    }
    //    else
    //    {
    //        followPlayer = false;
    //    }

    //    if (other.gameObject.name == "Polygon (1)")
    //    {
    //        followPlayer2 = true;
    //    }
    //    else
    //    {
    //        followPlayer2 = false;
    //    }
    //}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Ground")
        {
            countDown = true;
        }
    }
}
