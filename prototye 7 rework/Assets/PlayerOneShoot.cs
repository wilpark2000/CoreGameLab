using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOneShoot : MonoBehaviour
{
    public GameObject ball;
    GameObject ballClone;
    public Transform shotLoc;
    public float x = 10;
    public float y = 10;
    public int ballCount;
    public float shotStrength;
    private float maxStrength = 1200;
    private float minStrength = 200;
    public Slider power;
    public Text balls;
    public Transform player;
    Rigidbody2D rb;

    void Start()
    {
        ballCount = 0;
        balls = GameObject.Find("ScoreKeeper").GetComponent<Text>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        balls.text = "Shots available: " + ballCount;

        if (Input.GetKey(KeyCode.W) && shotStrength < maxStrength)
        {
            shotStrength += 100;
        }
        else if (Input.GetKey(KeyCode.S) && shotStrength > minStrength)
        {
            shotStrength -= 100;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            /*transform.Rotate(Vector3.forward);*/
            Vector3 point = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            Vector3 axis = new Vector3(0, 0, 1);
            shotLoc.transform.RotateAround(point, axis, 3);
        }

        if (Input.GetKey(KeyCode.E))
        {
            Vector3 point = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            Vector3 axis = new Vector3(0, 0, 1);
            shotLoc.transform.RotateAround(point, axis, -3);
        }

        if (Input.GetKeyDown(KeyCode.F) && ballCount > 0)
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


        Destroy(ballClone.gameObject);
    }

}
