using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player2Shoot : MonoBehaviour
{
    public GameObject ball;
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

    void Start()
    {
        ballCount = 0;
        balls = GameObject.Find("ScoreKeeper").GetComponent<Text>();
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

        if (Input.GetKey(KeyCode.B))
        {
            /*transform.Rotate(Vector3.forward);*/
            Vector3 point = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            Vector3 axis = new Vector3(0, 0, 1);
            shotLoc.transform.RotateAround(point, axis, 3);
        }

        if (Input.GetKey(KeyCode.M))
        {
            Vector3 point = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            Vector3 axis = new Vector3(0, 0, 1);
            shotLoc.transform.RotateAround(point, axis, -3);
        }



        if (Input.GetKeyDown(KeyCode.RightControl) && ballCount > 0)
        {
            ball = Instantiate(ball, shotLoc.position, shotLoc.rotation) as GameObject;
            ball.GetComponent<Rigidbody2D>().AddForce(ball.transform.up * shotStrength);
            ballCount--;
        }

        Destroy(ball.gameObject, 2f);

        power.value = shotStrength;


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "shot")
        {
            ballCount++;
        }


    }

}
