using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondRadar : MonoBehaviour
{
    GameObject p1;
    GameObject p2;

    public AudioSource audioPlayer1;
    public AudioSource audioPlayer2;
    void Start()
    {
        audioPlayer1 = GetComponent<AudioSource>();
        audioPlayer2 = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance1 = Vector2.Distance(p1.transform.position, transform.position);
        float distance2 = Vector2.Distance(p2.transform.position, transform.position);

        if (Mathf.Abs(distance1) <= 3)
        {
            audioPlayer1.Play();
        }
        if (Mathf.Abs(distance1) > 3)
        {
            audioPlayer1.Pause();
        }

        if (Mathf.Abs(distance2) <= 3)
        {
            audioPlayer2.Play();
        }
        if (Mathf.Abs(distance2) > 3)
        {
            audioPlayer2.Pause();
        }
    }
}
