using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvCorMove : MonoBehaviour
{
    GameObject p1;
    GameObject p2;

    public AudioSource audioPlayer1;
    public AudioSource audioPlayer2;

    Vector2 direction;
    float spinForce;

    Rigidbody2D rb;
    public float speed = 12;
    float movement;
    bool pushRight = false;
    bool pushLeft = false;
    bool p1InRange = false;
    bool p2InRange = false;

    // Start is called before the first frame update
    void Start()
    {
        p1 = GameObject.Find("Polygon");
        p2 = GameObject.Find("Polygon (1)");

        audioPlayer1 = GetComponent<AudioSource>();
        //audioPlayer2 = GetComponent<AudioSource>();

        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        spinForce = Random.Range(70f, 90f);

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction, ForceMode2D.Impulse);
        rb.AddTorque(spinForce);
        Vector2 movement = new Vector2(Random.Range(-320, 320), Random.Range(-320, 300));
        rb.AddForce(movement);
    }
    void Update()
    {
        float distance1 = Vector2.Distance(p1.transform.position, transform.position);
        float distance2 = Vector2.Distance(p2.transform.position, transform.position);

        if (Mathf.Abs(distance1) <= 7 && Mathf.Abs(distance1) >= 3f)
        {
            p1InRange = true;      
        }
        if (Mathf.Abs(distance1) > 7 || Mathf.Abs(distance1) < 3f)
        {
            p1InRange = false;
        }

        if (p1InRange == true)
        {
            audioPlayer1.Play();
        }
        else
        {
            audioPlayer1.Pause();
        }
        //if (Mathf.Abs(distance2) <= 7 && Mathf.Abs(distance2) > 3f) 
        //{
        //    audioPlayer2.Play();
        //}
        //if (Mathf.Abs(distance2) > 7 || Mathf.Abs(distance2) < 3f)
        //{
        //    audioPlayer2.Pause();
        //}


        if (transform.position.x <= 14.2)
        {
            pushRight = true;
        }
        else
        {
            pushRight = false;
        }

        if (pushRight == true)
        {
            rb.AddForce(new Vector2(300, 0));
        }

        if (transform.position.x >= 30.4)
        {
            pushLeft = true;
        }
        else
        {
            pushLeft = false;
        }

        if (pushLeft == true)
        {
            rb.AddForce(new Vector2(-290, 0));
        }
    }
}
