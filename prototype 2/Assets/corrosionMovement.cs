using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corrosionMovement : MonoBehaviour
{
    Vector2 direction;
    float spinForce;

    public Rigidbody2D rb;
    public float speed = 12;
    float movement = 12;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        spinForce = Random.Range(50.0f, 40.0f);

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction, ForceMode2D.Impulse);
        rb.AddTorque(spinForce);
        Vector2 movement = new Vector2(Random.Range(-6, 6), Random.Range(-6, 6));
        rb.AddForce(movement);
        print(movement);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector2 Movement = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        //rb.AddForce(Movement);
        //print(Movement);
    }
}
