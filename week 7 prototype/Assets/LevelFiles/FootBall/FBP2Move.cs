using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FBP2Move : MonoBehaviour
{
    public GameObject weaponPrefab;

    GameObject ballClone;

    public Transform shotLoc;

    public float x = 10;
    public float y = 10;

    public int ballCount;

    public float shotStrength;

    public Text balls;
    public Transform player;

    private bool jump = true;

    Rigidbody2D rb;
    float timer;

    int numberOfJumps;
    float bulletTimer;

    bool maxReached;
    public Transform ammoTimer;
    float difference;
    float xScale;
    float xTransform;

    void Awake()
    {
        shotStrength = 1100;
        maxReached = false;
    }
    void Start()
    {
        ballCount = 4;
        balls = GameObject.FindGameObjectWithTag("RegularShotP2").GetComponent<Text>();
        rb = GetComponent<Rigidbody2D>();
        bulletTimer = 5;
        difference = (Time.deltaTime / 5) / 1.22f;
    }

    // Update is called once per frame
    void Update()
    {
        if (ballCount >= 7)
        {
            maxReached = true;
        }
        else
        {
            maxReached = false;
            //xScale = ammoTimer.transform.localScale.x - difference;
            //ammoTimer.transform.localScale = new Vector2(xScale, ammoTimer.transform.localScale.y);
        }

        if (maxReached == true)
        {
            ammoTimer.transform.localScale = new Vector2(1, ammoTimer.transform.localScale.y);
        }

        if (maxReached == false)
        {
            if (bulletTimer >= 0)
            {
                bulletTimer -= Time.deltaTime;
                xScale = ammoTimer.localScale.x;
                ammoTimer.transform.localScale = new Vector2(xScale - difference, ammoTimer.transform.localScale.y);
            }

            if (bulletTimer <= 0)
            {
                ballCount++;
                bulletTimer = 5;
                ammoTimer.transform.localScale = new Vector2(1, ammoTimer.transform.localScale.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (numberOfJumps > 0)
            {
                float jumpV = 18f;
                rb.velocity = Vector2.up * jumpV;
                numberOfJumps--;
            }
        }

        float speed = 5f;

        if (Input.GetKey(KeyCode.N))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        else if (Input.GetKey(KeyCode.Comma))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        Vector3 point = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        Vector3 axis = new Vector3(0, 0, 1);

        balls.text = "shots: " + ballCount;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            /*transform.Rotate(Vector3.forward);*/
            shotLoc.transform.RotateAround(point, axis, 5);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            shotLoc.transform.RotateAround(point, axis, -5);
        }


        if (Input.GetKeyDown(KeyCode.Period) && ballCount > 0)
        {
            for (int i = 0; i < 8; i++)
            {
                float spread = Random.Range(-10, 10);
                Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, 0, spread));
                ballClone = Instantiate(weaponPrefab, shotLoc.position, shotLoc.rotation * bulletRotation) as GameObject;
                ballClone.GetComponent<Rigidbody2D>().AddForce(ballClone.transform.up * 700);
            }
            ballCount--;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            numberOfJumps = 2;
            Debug.Log(numberOfJumps);
        }
    }
}
