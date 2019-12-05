using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponTwo : MonoBehaviour
{
    float timer;
    GameObject shot;
    bool didntTouchPlatform;
    bool didntTouchPlayer;
    int timesBounced;

    void Awake()
    {
        shot = GameObject.FindGameObjectWithTag("weapon2");
    }

    void Start()
    {
        timer = 12f;
        didntTouchPlatform = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 14 || transform.position.x <= -14)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.y >= 10 || transform.position.y <= -10)
        {
            Destroy(this.gameObject);
        }

        shot = GameObject.FindGameObjectWithTag("weapon2");

        if (didntTouchPlatform == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0 || timesBounced >= 6 /*|| (didntTouchPlayer == false)*/)
            {
                Destroy(shot.gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            timesBounced++;
            didntTouchPlatform = false;
        }

        if (other.gameObject.tag == "player")
        {
            didntTouchPlayer = false;
        }
    }
}
