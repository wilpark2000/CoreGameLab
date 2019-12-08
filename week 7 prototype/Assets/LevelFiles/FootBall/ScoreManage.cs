using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManage : MonoBehaviour
{
    public GameObject glow1;
    public GameObject glow2;
    public Animator anim;
    bool matchEnded;
    bool p1GoalTouched;
    bool p2GoalTouched;
    public float timer;
    float matchTimer;
    float p1GoalTimer;
    float p2GoalTimer;
    int p1Score;
    int p2Score;
    Text P1ScoreText;
    Text P2ScoreText;
    Text matchTimeLeft;
    Text winTimer;
    Text playerWin;

    public static bool p1Win;
    public static bool p2Win;
    public static bool tie;

    public static float scoreDif;
    void Start()
    {
        anim = GetComponent<Animator>();
        p1Win = false;
        p2Win = false;
        tie = false;

        p1GoalTouched = false;
        p2GoalTouched = false;
        p1GoalTimer = 3;
        p2GoalTimer = 3;
        matchEnded = false;
        timer = 5;
        matchTimer = 90;
        P1ScoreText = GameObject.Find("ScoreP1").GetComponent<Text>();
        P2ScoreText = GameObject.Find("ScoreP2").GetComponent<Text>();
        matchTimeLeft = GameObject.Find("matchTimer").GetComponent<Text>();
        winTimer = GameObject.Find("win").GetComponent<Text>();
        playerWin = GameObject.Find("victoryText").GetComponent<Text>();

        winTimer.text = "";
        playerWin.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -3);

        if (p1GoalTouched == true)
        {
            glow1.GetComponent<SpriteRenderer>().enabled = true;
            p1GoalTimer -= Time.deltaTime;
            if (p1GoalTimer <= 0)
            {
                p1GoalTimer = 3;
                p1GoalTouched = false;
            }
        }
        if (p1GoalTouched == false)
        {
            glow1.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (p2GoalTouched == true)
        {
            glow2.GetComponent<SpriteRenderer>().enabled = true;
            p2GoalTimer -= Time.deltaTime;
            if (p2GoalTimer <= 0)
            {
                p2GoalTimer = 3;
                p2GoalTouched = false;
            }
        }
        if (p2GoalTouched == false)
        {
            glow2.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (matchTimer > 0)
        {
            matchTimer -= Time.deltaTime;
        }
        P1ScoreText.text = "score: " + p1Score;
        P2ScoreText.text = "score: " + p2Score;
        matchTimeLeft.text = "" + Mathf.Round(matchTimer);

        if (matchTimer <= 0)
        {
            matchEnded = true;
            matchTimer = 0;
            timer -= Time.deltaTime;
            if (p1Score > p2Score)
            {
                scoreDif = Mathf.Abs(p2Score - p1Score);
                p1Win = true;
                //winTimer.text = "" + Mathf.Round(timer);
                //playerWin.text = "Player 1 Wins!";
                //SceneManager.LoadScene("StartScene");
            }
            if (p1Score < p2Score) 
            {
                scoreDif = Mathf.Abs(p2Score - p1Score);
                p2Win = true;
                //winTimer.text = Mathf.Round(timer).ToString();
                //playerWin.text = "Player 2 Wins!";
                //SceneManager.LoadScene("StartScene");
            }

            if (p1Score == p2Score)
            {
                tie = true;
                //winTimer.text = Mathf.Round(timer).ToString();
                //playerWin.text = "It's a tie!";
                //SceneManager.LoadScene("StartScene");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "P1Goal")
        {
            if (matchEnded == false && p1GoalTouched == false)
            {
                p1GoalTouched = true;
                p2Score++;
            }
        }

        if (other.gameObject.tag == "P2Goal")
        {
            if (matchEnded == false && p2GoalTouched == false)
            {
                p2GoalTouched = true;
                p1Score++;
            }
        }
    }
}
