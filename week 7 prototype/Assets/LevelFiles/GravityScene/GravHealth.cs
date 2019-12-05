using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GravHealth : MonoBehaviour
{
    public static float playerHealth;
    public Text health;
    Rigidbody2D rb;
    float timer;
    public Text secondsTilNextMatch;
    public Text playerWin;
    public GameObject player;
    public GameObject shotLoc;

    void Awake()
    {
        //playerHealth = 100.0f;
        secondsTilNextMatch.text = "";
        playerWin.text = "";
        timer = 8.0f;
    }

    void Start()
    {
        secondsTilNextMatch = GameObject.Find("victoryText").GetComponent<Text>();
        playerWin = GameObject.Find("win").GetComponent<Text>();

        playerHealth = 100.0f;
        //health = GetComponent<Text>();
        rb = GetComponent<Rigidbody2D>();
        secondsTilNextMatch.text = "";
        playerWin.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -6)
        {
            playerHealth -= 100;
        }

        if (playerHealth <= 0)
        {
            playerHealth = 0;
        }

        if (playerHealth <= 0)
        {
            timer -= Time.deltaTime;
            player.GetComponent<Renderer>().enabled = false;
            shotLoc.GetComponent<Renderer>().enabled = false;

            //secondsTilNextMatch.text = "Player 2 wins!! ";
            //playerWin.text = (Mathf.Round(timer)).ToString("0");
            //if (timer <= 0)
            //{
            //    SceneManager.LoadScene("FallScene");
            //}
        }
        health.text = "" + Mathf.Round(playerHealth) + "%";
    }

    //void LoseHealth()
    //{
    //    playerHealth -= 6f;
    //}

    //void LoseHealthBouncer()
    //{
    //    playerHealth -= 10f;
    //}
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "weapon")
        {
            playerHealth -= 10f;
            //Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "weapon2")
        {
            playerHealth -= 5f;
            //Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "weapon3")
        {
            playerHealth -= 1f;
        }

        if (other.gameObject.tag == "weapon5")
        {
            playerHealth -= 2f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "weapon4")
        {
            playerHealth -= 1.5f;
        }
    }
}