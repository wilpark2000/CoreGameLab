using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3BulletSpawn : MonoBehaviour
{
    public GameObject anim;
    public GameObject sat;
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
        animTimer = 2.4f;
        weaponNumber = Random.Range(0, 4);

        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();

        timer = 5;
        timer2 = 2;

        xpos = Random.Range(-7, 7);
        xpos2 = Random.Range(-7, 7);

        ypos = 2.6f;
        normalBulletLoop = Random.Range(4, 7);
        skilledBulletLoop = Random.Range(6, 10);

        gravDecider = Random.Range(-1, 1);
        gravDecider2 = Random.Range(-1, 1);

        yposDecider = Random.Range(-1, 1);
        yposDecider2 = Random.Range(-1, 1);
    }

    void Update()
    {

        sat.transform.position = new Vector3(sat.transform.position.x + 0.0008f, sat.transform.position.y - 0.0005f, sat.transform.position.z);
        sat.transform.rotation = Quaternion.Slerp(sat.transform.rotation, Quaternion.Euler(0, 0, 120), Time.deltaTime * 0.0014f);

        animTimer -= Time.deltaTime;
        if (animTimer <= 0)
        {
            anim.GetComponent<SpriteRenderer>().enabled = false;
        }

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
                timer = Random.Range(6f, 8f);
                gravDecider = Random.Range(-1, 1);
                yposDecider = Random.Range(-1, 1);
            }

            if (isNegativeGrav == false)
            {
                bullet = Instantiate(bullets, new Vector2(xpos, ypos2), transform.rotation);
                bullet.GetComponent<Rigidbody2D>().gravityScale = 2;
                xpos = Random.Range(-5.5f, 5.5f);
                timer = Random.Range(5f, 7f);
                gravDecider = Random.Range(-1, 1);
                yposDecider2 = Random.Range(-1, 1);
            }
        }

        timer2 -= Time.deltaTime;
        if (timer2 <= 0)
        {
            if (isNegativeGrav2 == true)
            {
                bullet = Instantiate(bulletsPrefabs[weaponNumber], new Vector2(xpos2, ypos2), transform.rotation);
                bullet.GetComponent<Rigidbody2D>().gravityScale = -2;
                xpos2 = Random.Range(-5.5f, 5.5f);
                weaponNumber = Random.Range(0, 4);
                timer2 = Random.Range(4f, 6f);
            }

            if (isNegativeGrav2 == false)
            {
                bullet = Instantiate(bulletsPrefabs[weaponNumber], new Vector2(xpos2, ypos2), transform.rotation);
                bullet.GetComponent<Rigidbody2D>().gravityScale = 2;
                xpos2 = Random.Range(-5.5f, 5.5f);
                weaponNumber = Random.Range(0, 4);
                timer2 = Random.Range(4f, 6f);
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