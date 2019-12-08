using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    public static int playerHealth;
    Rigidbody2D rb;
    float timer;
    public Text secondsTilNextMatch;
    public Text playerWin;
    Text healthP1;
    public GameObject player;
    public GameObject shotLoc;
    public static bool killed = false;
    public static bool fell = false;
    public static bool alive = true;

    void Awake()
    {
        playerHealth = 100;
        //secondsTilNextMatch.text = "";
        //playerWin.text = "";
        timer = 8.0f;
    }

    void Start()
    {
        healthP1 = GameObject.Find("P1Health").GetComponent<Text>();

        //secondsTilNextMatch = GameObject.Find("victoryText").GetComponent<Text>();
        //playerWin = GameObject.Find("win").GetComponent<Text>();
        
        

        playerHealth = 100;
        //healthBar = GetComponent<Slider>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        healthP1.text = "" + playerHealth + "%";
        PlayerPrefs.SetFloat("s1P1Health", playerHealth);
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            timer -= Time.deltaTime;
            //player.GetComponent<Renderer>().enabled = false;
            //shotLoc.GetComponent<Renderer>().enabled = false;
            killed = true;

            alive = false;

            //secondsTilNextMatch.text = "Player 2 wins!! ";
            //playerWin.text = (Mathf.Round(timer)).ToString("0");
            //if (timer <= 0)
            //{
            //    SceneManager.LoadScene("BounceScene");
            //}
        }

        if (transform.position.y <= -6)
        {
            if (Player2Health.playerHealth > 0)
            {
                if (alive == true)
                {
                    playerHealth -= 100;
                }
            }
            timer -= Time.deltaTime;
            //player.GetComponent<Renderer>().enabled = false;
            //shotLoc.GetComponent<Renderer>().enabled = false;
            fell = true;

            alive = false;
            //secondsTilNextMatch.text = "Player 2 wins!! ";
            //playerWin.text = (Mathf.Round(timer)).ToString("0");
            //if (timer <= 0)
            //{
            //    SceneManager.LoadScene("BounceScene");
            //}
        }
    }

    void LoseHealth()
    {
        playerHealth -= 100;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Player2Health.playerHealth > 0)
        {
            if (other.gameObject.tag == "weapon")
            {
                LoseHealth();
                Destroy(other.gameObject);
            }
        }
    }
}
