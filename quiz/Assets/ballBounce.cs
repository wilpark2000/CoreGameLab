using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBounce : MonoBehaviour
{
    SpriteRenderer sr;
    AudioSource boing;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        boing = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        boing.Play();
        Color c = collision.gameObject.GetComponent<SpriteRenderer>().color;
        sr.color = c;
    }

    void Update()
    {
        
    }
}
