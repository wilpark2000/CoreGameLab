using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon2Script : MonoBehaviour
{
     public float speed;
    private Transform target;
    float dist;
    BoxCollider2D collide;
    Rigidbody2D rb;
    public GameObject demonPlasma;
    public Transform shotLoc;
    float timer;
    int health;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        collide = this.GetComponent<BoxCollider2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = Random.Range(2f, 6f);
        health = 60;
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = target.position - transform.position;

        if (Vector2.Distance(transform.position, target.position) > Random.Range(10, 16))
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(demonPlasma, shotLoc.position, shotLoc.rotation);
            timer = Random.Range(2f, 4f);
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "weaponOne")
        {
            health -= 20;
        }
    }
}