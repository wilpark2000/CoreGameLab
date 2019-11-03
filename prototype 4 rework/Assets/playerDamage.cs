using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerDamage : MonoBehaviour
{
    public int health = 100;
    public Rigidbody2D rb;
    public float timer = 0.9f;
    public Slider healthBar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Damaged()
    {
        health -= 20;
        //if (health <= 0)
        //{
        //    SceneManager.LoadScene("Death");
        //}
    }

    void Death()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("Death");
        }
    }

    void Update()
    {
        healthBar.value = health;
        Death();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        enemyFollow enemy = collision.collider.GetComponent<enemyFollow>();
        Debug.Log("Test");
        if (enemy != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Damaged();
                timer = 0.9f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemyPlasma")
        {
            Damaged();
        }
        //demonPlasma plasma = collision.collider.GetComponent<demonPlasma>();
        //if (plasma != null)
        //{
        //    health -= 15;
        //}
    }
}
