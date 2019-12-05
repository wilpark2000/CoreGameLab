using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrosionP2Move : MonoBehaviour
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

    void Awake()
    {
        shotStrength = 800;
    }
    void Start()
    {
        ballCount = 1;
        balls = GameObject.FindGameObjectWithTag("RegularShotP2").GetComponent<Text>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speed = 3;

        if (Input.GetKey(KeyCode.N))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Comma))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.K))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.M))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        Vector3 point = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        Vector3 axis = new Vector3(0, 0, 1);

        balls.text = "shots: " + ballCount;

        if (Input.GetKey(KeyCode.LeftArrow))
        { 
            shotLoc.transform.RotateAround(point, axis, 5);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            shotLoc.transform.RotateAround(point, axis, -5);
        }


        if (Input.GetKeyDown(KeyCode.Period) && ballCount > 0)
        {
            ballClone = Instantiate(weaponPrefab, shotLoc.position, shotLoc.rotation) as GameObject;
            ballClone.GetComponent<Rigidbody2D>().AddForce(shotLoc.transform.up * shotStrength);
            ballCount--;
            ballClone.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Corrosion")
        {
            transform.position = new Vector3(-1.75f, -2, 10);
        }
    }
}