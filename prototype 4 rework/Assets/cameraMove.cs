using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public Transform player;
    public float speed;


    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        if (transform.position.x <= -30)
        {

            transform.position = new Vector3(-30f, transform.position.y, transform.position.z);

        }

        if (transform.position.x >= 30)
        {

            transform.position = new Vector3(30f, transform.position.y, transform.position.z);

        }

        if (transform.position.y <= -20)
        {

            transform.position = new Vector3(transform.position.x, -20, transform.position.z);

        }

        if (transform.position.y >= 20)
        {

            transform.position = new Vector3(transform.position.x, 20, transform.position.z);

        }
    }
}
