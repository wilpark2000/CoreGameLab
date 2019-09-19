using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text MyText;
    private int points;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MyText.text = "Score: " + points;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        points++;
    }
}
