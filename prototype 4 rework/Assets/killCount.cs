using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class killCount : MonoBehaviour
{
    public static int score;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        score = 0;
        PlayerPrefs.SetInt("killsCommitted", score);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Kills: " + score;
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("killsCommitted", score); // save only OnDestroy, aka when going out of the scene
    }
}
