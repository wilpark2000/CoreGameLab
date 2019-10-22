using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBoundaries : MonoBehaviour
{
    void FixedUpdate()
    {

        if (transform.position.x <= -28.26)
        {

            transform.position = new Vector3(-28.26f, transform.position.y, transform.position.z);

        }

        if (transform.position.x >= 31.73)
        {

            transform.position = new Vector3(31.73f, transform.position.y, transform.position.z);

        }

        if (transform.position.y <= -19.05)
        {

            transform.position = new Vector3(transform.position.x, -19.05f, transform.position.z);

        }

        if (transform.position.y >= 20.26)
        {

            transform.position = new Vector3(transform.position.x, 20.26f, transform.position.z);

        }
    }
}