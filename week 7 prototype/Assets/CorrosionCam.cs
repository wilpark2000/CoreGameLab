using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrosionCam : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(player.transform.position.x + 1.2f, transform.position.y);

        if (transform.position.x <= -0.12)
        {

            transform.position = new Vector2(-0.12f, transform.position.y);

        }

        if (transform.position.x >= 33.8)
        {

            transform.position = new Vector2(33.8f, transform.position.y);

        }
    }
}
