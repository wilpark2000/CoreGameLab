using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement1 : MonoBehaviour
{
    public Transform playerBomb;

    void FixedUpdate()
    {
        transform.position = new Vector3(playerBomb.position.x + 20, transform.position.y, transform.position.z);

        if (transform.position.x <= -19.9)
        {

            transform.position = new Vector3(-19.9f, transform.position.y, transform.position.z);

        }

        if (transform.position.x >= 146)
        {

            transform.position = new Vector3(145f, transform.position.y, transform.position.z);

        }
    }
}
