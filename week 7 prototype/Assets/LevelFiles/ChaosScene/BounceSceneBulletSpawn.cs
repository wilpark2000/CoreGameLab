using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSceneBulletSpawn : MonoBehaviour
{
    public float timer;
    public float timer2;
    public float timer3;

    public GameObject bullets;
    GameObject bullet;
    GameObject bullet2;
    GameObject bullet3;
    GameObject[] bulletsPrefabs = new GameObject[2];

    float xpos;
    float ypos;
    Rigidbody2D rb;
    CircleCollider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();

        timer = 10;
        timer2 = 5;
        timer3 = 15;

        xpos = Random.Range(-5, 5);
        ypos = 6;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            bullet = Instantiate(bullets, new Vector2(xpos, ypos), transform.rotation);
            timer = Random.Range(8.5f, 11);
            xpos = Random.Range(-5, 5);
        }

        timer2 -= Time.deltaTime;
        if (timer2 <= 0)
        {
            bullet2 = Instantiate(bulletsPrefabs[0], new Vector2(xpos, ypos), transform.rotation);
            timer2 = Random.Range(8.5f, 11);
            xpos = Random.Range(-5, 5);
        }

        timer3 -= Time.deltaTime;
        if (timer3 <= 0)
        {
            bullet3 = Instantiate(bulletsPrefabs[1], new Vector2(xpos, ypos), transform.rotation);
            timer = Random.Range(8.5f, 13f);
            xpos = Random.Range(-5, 5);
        }
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Destroy(bullet.gameObject);
    //    }
    //}
}
