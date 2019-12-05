using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player2Health : MonoBehaviour
{
    public static int playerHealth;
    public Slider healthBar;
    Rigidbody2D rb;
    float timer;
    public Text secondsTilNextMatch;
    public Text playerWin;
    public GameObject player;
    public GameObject shotLoc;
    public static bool killed = false;
    public static bool fell = false;
    public static bool alive = true;

    void Awake()
    {
        playerHealth = 100;
        healthBar.value = playerHealth;
        //secondsTilNextMatch.text = "";
        //playerWin.text = "";
        timer = 8.0f;
    }

    void Start()
    {
        //secondsTilNextMatch = GameObject.Find("victoryText2").GetComponent<Text>();
        //playerWin = GameObject.Find("win2").GetComponent<Text>();

        playerHealth = 100;
        //healthBar = GetComponent<Slider>();
        rb = GetComponent<Rigidbody2D>();
        secondsTilNextMatch.text = "";
        playerWin.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("s2P1Health", playerHealth);

        if (playerHealth <= 0)
        {
            timer -= Time.deltaTime;
            player.GetComponent<Renderer>().enabled = false;
            shotLoc.GetComponent<Renderer>().enabled = false;
            killed = true;
            alive = false;

            //secondsTilNextMatch.text = "Player 1 wins!! ";
            //playerWin.text = (Mathf.Round(timer)).ToString("0");
            //if (timer <= 0)
            //{
            //    SceneManager.LoadScene("BounceScene");
            //}
        }

        if (transform.position.y <= -6)
        {
            timer -= Time.deltaTime;
            player.GetComponent<Renderer>().enabled = false;
            shotLoc.GetComponent<Renderer>().enabled = false;
            fell = true;
            alive = false;

            //secondsTilNextMatch.text = "Player 1 wins!! ";
            //playerWin.text = (Mathf.Round(timer)).ToString("0");
            //if (timer <= 0)
            //{
            //    SceneManager.LoadScene("BounceScene");
            //}
        }
        healthBar.value = playerHealth;
    }

    void LoseHealth()
    {
        playerHealth -= 100;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "weapon")
        {
            LoseHealth();
            Destroy(other.gameObject);
        }
    }
}
