using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player2Shoot : MonoBehaviour
{
    public GameObject ball;
    GameObject ballClone;
    public Transform shotLoc;
    public float x = 10;
    public float y = 10;
    private int ballCount;
    public float shotStrength;
    private float maxStrength = 1200;
    private float minStrength = 200;
    public Slider power;
    public Text balls;
    public Transform player;
    Rigidbody2D rb;
    float timer;

    void Awake()
    {
        shotStrength = 700;
    }

    void Start()
    {
        ballCount = 1;
        //balls = GameObject.Find("ScoreKeeper").GetComponent<Text>();
        rb = GetComponent<Rigidbody2D>();
        timer = 2;

    }

    // Update is called once per frame
    void Update()
    {
        balls.text = "Shots available: " + ballCount;

        if (Input.GetKeyDown(KeyCode.UpArrow) && shotStrength < maxStrength)
        {
            shotStrength += 100;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && shotStrength > minStrength)
        {
            shotStrength -= 100;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            /*transform.Rotate(Vector3.forward);*/
            Vector3 point = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            Vector3 axis = new Vector3(0, 0, 1);
            shotLoc.transform.RotateAround(point, axis, 3);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 point = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            Vector3 axis = new Vector3(0, 0, 1);
            shotLoc.transform.RotateAround(point, axis, -3);
        }

        if (Input.GetKeyDown(KeyCode.Period) && ballCount > 0)
        {
            ballClone = Instantiate(ball, shotLoc.position, shotLoc.rotation) as GameObject;
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
        //Destroy(ballClone.gameObject);
    }
}
