using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneBPOneMovement : MonoBehaviour
{
    public GameObject ball;
    GameObject ballClone;
    public GameObject shotLoc;
    public float x = 10;
    public float y = 10;
    public int ballCount;
    public float shotStrength;
    private float maxStrength = 1200;
    private float minStrength = 200;
    public Slider power;
    public Text balls;
    public GameObject player;
    Rigidbody2D rb;

    private bool jump = true;

    void Awake()
    {
        shotStrength = 700;
        rb = transform.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        ballCount = 1;
        balls = GameObject.Find("ScoreKeeper").GetComponent<Text>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        shotLoc = GameObject.FindGameObjectWithTag("shotLoc");
        player = GameObject.FindGameObjectWithTag("Player");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jump == true)
            {
                float jumpV = 20f;
                rb.velocity = Vector2.up * jumpV;
                jump = false;
            }
        }

        float speed = 5f;

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }


    Vector3 point = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        Vector3 axis = new Vector3(0, 0, 1);

        balls.text = "Shots available: " + ballCount;

        if (Input.GetKeyDown(KeyCode.W) && shotStrength < maxStrength)
        {
            shotStrength += 100;
        }
        else if (Input.GetKeyDown(KeyCode.S) && shotStrength > minStrength)
        {
            shotStrength -= 100;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            /*transform.Rotate(Vector3.forward);*/
            shotLoc.transform.RotateAround(point, axis, 5); 
        }

        if (Input.GetKey(KeyCode.E))
        {
            shotLoc.transform.RotateAround(point, axis, -5);
        }


        if (Input.GetKeyDown(KeyCode.F) && ballCount > 0)
        {
            ballClone = Instantiate(ball, shotLoc.transform.position, shotLoc.transform.rotation) as GameObject;
            ballClone.GetComponent<Rigidbody2D>().AddForce(shotLoc.transform.up * shotStrength);
            ballCount--;
        }
        power.value = shotStrength;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "shot")
        {
            ballCount++;
            Destroy(other.gameObject);
        }
        Destroy(ballClone.gameObject);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            jump = true;
        }
    }

}

