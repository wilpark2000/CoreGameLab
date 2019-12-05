using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponOne : MonoBehaviour
{
    float timer;
    GameObject shot;
    bool didntTouchPlatform;
    Rigidbody2D rb;

    void Awake()
    {
        shot = GameObject.FindGameObjectWithTag("weapon");
        //isGravScene = false;

        //isP1 = false;
        //isP2 = false;

        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

        //p1Distance = Vector2.Distance(p1Script.transform.position, this.transform.position);
        //p2Distance = Vector2.Distance(p2Script.transform.position, this.transform.position);

        //if ((Mathf.Abs(p1Distance) - Mathf.Abs(p2Distance)) <= 0)
        //{
        //    isP1 = true;
        //    isP2 = false;
        //}
        //else
        //{
        //    isP1 = false;
        //    isP2 = true;
        //}

        timer = 1f;
        didntTouchPlatform = true;
       
        //gravScene = SceneManager.GetActiveScene();
        //string currentSceneName = gravScene.name;

        //if (currentSceneName == "GravityScene")
        //{
        //    isGravScene = true;
        //}
        //else
        //{
        //    isGravScene = false;
        //}
        
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

        shot = GameObject.FindGameObjectWithTag("weapon");

        if (didntTouchPlatform == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Destroy(shot.gameObject);
            }
        }

        //if (isGravScene == true)
        //{
        //    if (isP1 == true)
        //    {
        //        if (p1Script.isRotated == true)
        //        {
        //            rb.gravityScale = -2;
        //        }
        //        else if (p1Script.isRotated == false)
        //        {
        //            rb.gravityScale = 2;
        //        }
        //    }

        //    else if (isP2 == true)
        //    {
        //        if (p2Script.isRotated == true)
        //        {
        //            rb.gravityScale = -2;
        //        }
        //        else if(p2Script.isRotated == false)
        //        {
        //            rb.gravityScale = 2;
        //        }
        //    }

        //}
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            didntTouchPlatform = false;
        }
        else
        {
            didntTouchPlatform = true;
        }

        if (other.gameObject.tag == "Player")
        {
            Destroy(shot.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "OGGround")
        {
            this.rb.gravityScale = -2;
        }

        if (other.gameObject.tag == "Grav")
        {
            this.rb.gravityScale = 2;
        }
    }
}
