using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrosionMove : MonoBehaviour
{
    Vector2 direction;
    float spinForce;

    Rigidbody2D rb;
    public float speed = 12;
    float movement;
    bool pushLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        spinForce = Random.Range(70f, 90f);

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction, ForceMode2D.Impulse);
        rb.AddTorque(spinForce);
        Vector2 movement = new Vector2(Random.Range(-250, 250), Random.Range(-250, 250));
        rb.AddForce(movement);
    }
    void Update()
    {
       if (transform.position.x >= 13.59)
        {
            pushLeft = true;
        }

       if (pushLeft == true)
        {
            rb.AddForce(new Vector2(-320, 0));
            pushLeft = false;
        }
    }
}
