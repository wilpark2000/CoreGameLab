using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallPlatform : MonoBehaviour
{
    float timer;
    //float originalTime;
    bool playerOnPlatform;

    public GameObject platformTimer;

    Rigidbody2D rb;
    float startSize;
    float difference;
    float constant;
    Animator anim;

    void Awake()
    {
        startSize = platformTimer.transform.localScale.x;
        rb = GetComponent<Rigidbody2D>();
        timer = 8;
    }

    void Start()
    {
        //constant = timer /= startSize;
        anim = GetComponent<Animator>();
        rb.isKinematic = true;
        playerOnPlatform = false;
        //originalTime = timer;
        //difference = (0.016f / timer);

    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnPlatform == true)
        {
            platformTimer.transform.localScale = new Vector2(platformTimer.transform.localScale.x - 0.00428f, platformTimer.transform.localScale.y);

            if (timer <= 0)
            {
                platformTimer.GetComponent<SpriteRenderer>().enabled = false;
                anim.SetBool("timerUp", true);
            }
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                rb.isKinematic = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerOnPlatform = true;
        }  
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerOnPlatform = false;
        }
    }
}
