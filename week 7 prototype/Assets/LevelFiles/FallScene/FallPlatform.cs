using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallPlatform : MonoBehaviour
{
    float timer;
    float originalTime;
    bool playerOnPlatform;

    public GameObject platformTimer;

    Rigidbody2D rb;

    float difference;
    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = Random.Range(8, 14);
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb.isKinematic = true;
        playerOnPlatform = false;
        originalTime = timer;
        difference = (Time.deltaTime/(timer / platformTimer.transform.localScale.x)/1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnPlatform == true)
        {
            float xScale = platformTimer.transform.localScale.x - difference;
            platformTimer.transform.localScale = new Vector2(xScale, platformTimer.transform.localScale.y);

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
