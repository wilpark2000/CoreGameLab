using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class followMouse : MonoBehaviour
{
    public GameObject ball;
    public Transform shotLoc;
    public float x = 10;
    public float y = 10;
    private int ballCount;
    public float shotStrength;
    private float maxStrength = 3000;
    private float minStrength = 200;
    public Slider power;
    public Text balls;
   
    void Start()
    {
        ballCount = 4;
        shotStrength = 800;
        balls = GameObject.Find("ScoreKeeper").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        balls.text = "Balls left: " + ballCount;

        if (Input.GetKeyDown(KeyCode.W) && shotStrength < maxStrength)
        {
            shotStrength += 20;
        }
        else if (Input.GetKeyDown(KeyCode.S) && shotStrength > minStrength)
        {
            shotStrength -= 20;
        }

        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
        transform.up = direction;

        if (Input.GetMouseButtonDown(0) && ballCount > 0)
        {
            ball = Instantiate(ball, shotLoc.position, shotLoc.rotation) as GameObject;
            ball.GetComponent<Rigidbody2D>().AddForce(ball.transform.up * shotStrength);
            ballCount--;
        }

        power.value = shotStrength;

        
    }
}
