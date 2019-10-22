using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyDamage : MonoBehaviour
{
    public int health = 80;
    public Rigidbody2D rb;
    public int oneKill = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Damaged()
    {
        health -= 20;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            killCount.score += oneKill;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        plasmaMove plasma = collision.collider.GetComponent<plasmaMove>();
        Debug.Log("Test");
        if (plasma != null)
        {
            Damaged();
        }
    }
}
