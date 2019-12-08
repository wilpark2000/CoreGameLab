using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shoot : MonoBehaviour
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
    public Text balls;
    public Transform player;
    Rigidbody2D rb;
    float timer;

    void Awake()
    {
        shotStrength = 900;
    }
    void Start()
    {
        ballCount = 1;
        //balls = GameObject.Find("ScoreKeeper").GetComponent<Text>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.playerHealth > 0)
        {
            Vector3 point = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            Vector3 axis = new Vector3(0, 0, 1);

            balls.text = "Shot: " + ballCount;

            if (Input.GetKey(KeyCode.V))
            {
                /*transform.Rotate(Vector3.forward);*/
                shotLoc.transform.RotateAround(point, axis, 5);
            }

            if (Input.GetKey(KeyCode.N))
            {
                shotLoc.transform.RotateAround(point, axis, -5);
            }


            if (Input.GetKeyDown(KeyCode.F) && ballCount > 0)
            {
                ballClone = Instantiate(ball, shotLoc.position, shotLoc.rotation) as GameObject;
                ballClone.GetComponent<Rigidbody2D>().AddForce(shotLoc.transform.up * shotStrength);
                ballCount--;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.tag == "Ground")
        //{
        //    timer = 3f;
        //    timer -= Time.deltaTime;
        //    if (timer <= 0)
        //    {
        //        Destroy(ballClone.gameObject);
        //    }
        //}
        //if (other.gameObject.tag == "shot")                                                                          
        //{
        //    ballCount++;
        //    Destroy(other.gameObject);
        //}



        if (other.gameObject.tag == "shot")
        {
            ballCount++;
            Destroy(other.gameObject);
        }
        //Destroy(ballClone.gameObject);
    }

}
