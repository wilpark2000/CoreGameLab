using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    float totalScoreP1;
    float totalScoreP2;
    Text score1;
    Text score2;
    Text win;

    // Start is called before the first frame update
    void Start()
    {
        score1 = GameObject.Find("p1Score").GetComponent<Text>();
        score2 = GameObject.Find("p2Score").GetComponent<Text>();
        win = GameObject.Find("finalWin").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        totalScoreP1 = PlayerPrefs.GetFloat("p1TotalScore");
        totalScoreP2 = PlayerPrefs.GetFloat("p2TotalScore");

        score1.text = "" + totalScoreP1;
        score2.text = "" + totalScoreP2;

        if (totalScoreP1 > totalScoreP2) {
            win.text = "Player 1 Wins";
        }
        else if (totalScoreP1 < totalScoreP2)
        {
            win.text = "Player 2 Wins";
        }
        else if (totalScoreP1 == totalScoreP2)
        {
            win.text = "Draw";
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
