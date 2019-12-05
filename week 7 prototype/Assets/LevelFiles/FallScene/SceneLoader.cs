using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static bool p1Out;
    public static bool p2Out;

    Text secondsTilNextMatch;
    Text playerWin;

    public GameObject p1;
    public GameObject p2;
    int p1h;
    int p2h;

    float p1Live;
    float p2Live;

    float timer;
    void Start()
    {
        timer = 5;
        p1h = 1;
        p2h = 1;
        p1Out = false;
        p2Out = false;
        secondsTilNextMatch = GameObject.Find("victoryText").GetComponent<Text>();
        playerWin = GameObject.Find("win").GetComponent<Text>();

        secondsTilNextMatch.text = "";
        playerWin.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(p1Out);
        Debug.Log(p2Out);
        if(p1.transform.position.y <= -9)
        {
            p1h--;
        }
        if (p2.transform.position.y <= -9)
        {
            p2h--;
        }

        if (p1h > 0)
        {
            p1Live += Time.deltaTime;
        }
        if (p2h > 0)
        {
            p2Live += Time.deltaTime;
        }

        if (p1h < 1)
        {
            if (p1Live < p2Live)
            {
                p1Out = true;
            }
            else if (p1Live > p2Live)
            {
                p1Out = false;
            }
        }

        if (p2h < 1)
        {
            if (p2Live < p1Live)
            {
                p2Out = true;
            }
            else if (p2Live > p1Live)
            {
                p2Out = false;
            }
        }
        //if (p1Out == true)
        //{
        //    timer -= Time.deltaTime;

        //    secondsTilNextMatch.text = "Player 2 wins!! ";
        //    playerWin.text = (Mathf.Round(timer)).ToString("0");
        //    if (timer <= 0)
        //    {
        //        SceneManager.LoadScene("FootBall");
        //    }
        //}

        //if (p2Out == true)
        //{
        //    timer -= Time.deltaTime;
    
        //    secondsTilNextMatch.text = "Player 1 wins!! ";
        //    playerWin.text = (Mathf.Round(timer)).ToString("0");
        //    if (timer <= 0)
        //    {
        //        SceneManager.LoadScene("FootBall");
        //    }
        //}
    }
}
