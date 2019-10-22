using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    public float speed;
    private Transform target;
    public float dist;
    BoxCollider2D collide;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        collide = this.GetComponent<BoxCollider2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = target.position - transform.position;

        if (Vector2.Distance(transform.position, target.position) > dist)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }
}