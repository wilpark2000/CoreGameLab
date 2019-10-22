using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invWrapping : MonoBehaviour
{
    float max_x;
    float max_y;
    float min_x;
    float min_y;
    Rigidbody2D rb;

    //float randomPosition;


    // Start is called before the first frame update
    void Start()
    {
        max_x = 161f;
        max_y = 30.2f;
        min_x = 68.9f;
        min_y = -35.7f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(Vector2.left * 0.5f, ForceMode2D.Impulse);
        //float randomPosition = Random.Range(min_y, max_y);

        if (transform.position.x >= max_x)
        {
            //transform.position = new Vector2(max_x, transform.position.y);
            rb.AddForce(Vector2.left * 0.1f, ForceMode2D.Impulse);
        }

        if (transform.position.x <= min_x)
        {
            //transform.position = new Vector2(min_x, transform.position.y);
            rb.AddForce(Vector2.right * 0.1f, ForceMode2D.Impulse);
        }

        if (transform.position.y >= max_y)
        {
            transform.position = new Vector2(transform.position.x, min_y);
        }
        if (transform.position.y <= min_y)
        {
            transform.position = new Vector2(transform.position.x, max_y);
        }
    }
}
