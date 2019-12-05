using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLocMove : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        Vector3 axis = new Vector3(0, 0, 1);

        if (Input.GetKey(KeyCode.Q))
        {
            //transform.Rotate(Vector3.forward * 10 * Time.deltaTime);

            transform.RotateAround(player.transform.position, new Vector3(0, 0, 1), -5);
        }

        if (Input.GetKey(KeyCode.E))
        {
            //transform.Rotate(Vector3.back * 10 * Time.deltaTime);

            transform.RotateAround(player.transform.position, new Vector3(0, 0, 1), 5);
        }
    }
}
