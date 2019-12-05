using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3BulletSpawn : MonoBehaviour
{
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
    float ypos;
    float ypos2;

    int normalBulletLoop;
    int skilledBulletLoop;

    Rigidbody2D rb;
    CircleCollider2D col;

    bool isNegativeGrav;
    bool isNegativeGrav2;
    int gravDecider;
    int gravDecider2;

    bool yPosLoc;
    bool yPosLoc2;
    int yposDecider;
    int yposDecider2;

    void Start()
    {
        weaponNumber = Random.Range(0, 4);

        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();

        timer = 5;
        timer2 = 2;

        xpos = Random.Range(-5, 5);
        xpos2 = Random.Range(-5, 5);

        ypos = 4;
        normalBulletLoop = Random.Range(4, 7);
        skilledBulletLoop = Random.Range(6, 10);

        gravDecider = Random.Range(-1, 1);
        gravDecider2 = Random.Range(-1, 1);

        yposDecider = Random.Range(-1, 1);
        yposDecider2 = Random.Range(-1, 1);
    }

    void Update()
    {
        if (gravDecider == -1)
        {
            isNegativeGrav = true;
        }
        else
        {
            isNegativeGrav = false;
        }

        if (gravDecider2 == -1)
        {
            isNegativeGrav2 = true;
        }
        else
        {
            isNegativeGrav2 = false;
        }

        if (yposDecider == -1)
        {
            ypos = -2.25f;
        }
        else
        {
            ypos = 2.25f;
        }

        if (yposDecider2 == -1)
        {
            ypos2 = -2.25f;
        }
        else
        {
            ypos2 = 2.25f;
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (isNegativeGrav == true)
            {
                bullet = Instantiate(bullets, new Vector2(xpos, ypos), transform.rotation);
                bullet.GetComponent<Rigidbody2D>().gravityScale = -2;
                xpos = Random.Range(-5.5f, 5.5f);
                timer = Random.Range(9f, 12f);
                gravDecider = Random.Range(-1, 1);
                yposDecider = Random.Range(-1, 1);
            }

            if (isNegativeGrav == false)
            {
                bullet = Instantiate(bullets, new Vector2(xpos, ypos2), transform.rotation);
                bullet.GetComponent<Rigidbody2D>().gravityScale = 2;
                xpos = Random.Range(-5.5f, 5.5f);
                timer = Random.Range(9f, 12f);
                gravDecider = Random.Range(-1, 1);
                yposDecider2 = Random.Range(-1, 1);
            }
        }

        timer2 -= Time.deltaTime;
        if (timer2 <= 0)
        {
            if (isNegativeGrav2 == true)
            {
                bullet = Instantiate(bulletsPrefabs[weaponNumber], new Vector2(xpos2, 4), transform.rotation);
                bullet.GetComponent<Rigidbody2D>().gravityScale = -2;
                xpos2 = Random.Range(-5.5f, 5.5f);
                weaponNumber = Random.Range(0, 4);
                timer2 = Random.Range(6f, 9f);
            }

            if (isNegativeGrav2 == false)
            {
                bullet = Instantiate(bulletsPrefabs[weaponNumber], new Vector2(xpos2, 4), transform.rotation);
                bullet.GetComponent<Rigidbody2D>().gravityScale = 2;
                xpos2 = Random.Range(-5.5f, 5.5f);
                weaponNumber = Random.Range(0, 4);
                timer2 = Random.Range(6f, 9f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(bullet.gameObject);
        }
    }
}