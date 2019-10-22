using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public float points;
    public Text totalPoint;
    // Start is called before the first frame update
    void Start()
    {
        totalPoint = GetComponent<Text>();
        points = 0;
    }

    public void AddScore()
    {
        points += 50;
    }

    public void SubtractScore()
    {
        points -= 20;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "goodWheel")
        {
            Debug.Log("Collision detected");
            AddScore();
        }

        else if (other.gameObject.tag == "badWheel")
        {
            SubtractScore();
        }
    }
    void Update()
    {
        totalPoint.text = "Score: " + points;
    }
}
