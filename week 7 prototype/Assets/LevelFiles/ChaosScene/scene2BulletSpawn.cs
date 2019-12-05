using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene2BulletSpawn : MonoBehaviour
{
    public GameObject anim;
    float animTimer;
    int weaponNumber;

    float timer;
    float timer2;
    float timer3;
    public GameObject bullets;
    public GameObject[] bulletsPrefabs;

    GameObject bullet;
    GameObject bullet2;
    GameObject bullet3;
    GameObject bullet4;

    float xpos;
    float xpos2;
    float xpos3;
    float ypos;

    int normalBulletLoop;
    int skilledBulletLoop;

    Rigidbody2D rb;
    CircleCollider2D col;

    void Start()
    {
        animTimer = 3.07f;
        weaponNumber = Random.Range(0, 4);

        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();

        timer = 10;
        timer2 = 6;

        xpos = Random.Range(-5, 5);
        xpos2 = Random.Range(-5, 5);
        xpos3 = Random.Range(-5, 5);

        ypos = 4;

        for (int i = 0; i < 10; i++)
        {
            bullet = Instantiate(bullets, new Vector2(Random.Range(-7f, 7f), 1.4f), transform.rotation);
        }

        for (int j = 0; j < 5; j++)
        {
            bullet = Instantiate(bulletsPrefabs[0], new Vector2(Random.Range(-6f, 6f), 1.4f), transform.rotation);
        }

        for (int k = 0; k < 5; k++)
        {
            bullet = Instantiate(bulletsPrefabs[1], new Vector2(Random.Range(-6f, 6f), 1.4f), transform.rotation);
        }

        for (int l = 0; l < 5; l++)
        {
            bullet = Instantiate(bulletsPrefabs[2], new Vector2(Random.Range(-6f, 6f), 1.4f), transform.rotation);
        }

        for (int o = 0; o < 5; o++)
        {
            bullet = Instantiate(bulletsPrefabs[3], new Vector2(Random.Range(-6f, 6f), 1.4f), transform.rotation);
        }

        normalBulletLoop = Random.Range(4, 7);
        skilledBulletLoop = Random.Range(8, 14);
    }

    void Update()
    {
        animTimer -= Time.deltaTime;
        
        if (animTimer <= 0)
        {
            anim.GetComponent<SpriteRenderer>().enabled = false;
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            for (int i = 0; i < normalBulletLoop; i++)
            {
                bullet = Instantiate(bullets, new Vector2(xpos, 4), transform.rotation);
                xpos = Random.Range(-5.5f, 5.5f);
            }
            timer = Random.Range(10f, 15f);
            normalBulletLoop = Random.Range(4, 7);
        }

        timer2 -= Time.deltaTime;
        if (timer2 <= 0)
        {
            for (int j = 0; j < skilledBulletLoop; j++)
            {
                bullet = Instantiate(bulletsPrefabs[weaponNumber], new Vector2(xpos2, 4), transform.rotation);
                xpos2 = Random.Range(-5.5f, 5.5f);
                weaponNumber = Random.Range(0, 4);
            }
            timer2 = Random.Range(9f, 14f);
            skilledBulletLoop = Random.Range(8, 14);
        }

        //timer3 -= Time.deltaTime;
        //if (timer3 <= 0)
        //{
        //    bullet = Instantiate(bulletsPrefabs[1], new Vector2(xpos, ypos), transform.rotation);
        //    timer3 = Random.Range(8f, 11f);
        //    xpos = Random.Range(-5, 5);
        //}
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(bullet.gameObject);
        }
    }
}