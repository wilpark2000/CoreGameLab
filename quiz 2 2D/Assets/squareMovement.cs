using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squareMovement : MonoBehaviour
{
    public float speed;
    private Transform target;
    public float dist;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        speed = PlayerPrefs.GetInt("timerValue");
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.up = target.position - transform.position;*/
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }
}