using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bulletSpawn : MonoBehaviour
{
    public float timer;
    public GameObject bullets;
    GameObject bullet;
    float xpos;
    float ypos;
    Rigidbody2D rb;
    CircleCollider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();

        timer = 10;

        xpos = Random.Range(-5, 5);
        ypos = 4;
    }

    void Update()
    {
        if (transform.position.y >= 10 || transform.position.y <= -10)
        {
            Destroy(this.gameObject);
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            bullet = Instantiate(bullets, new Vector2(xpos,ypos), transform.rotation);
            timer = Random.Range(15f, 20f);
            xpos = Random.Range(-5, 5);
        }
    }

    public void MenuScreen()
    {
        SceneManager.LoadScene("StartScene");
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Destroy(bullet.gameObject);
    //    }
    //}
}