using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demonPlasma : MonoBehaviour
{
    float x = 30;
    float y = 20;
    public Rigidbody2D rb;
    BoxCollider2D collide;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collide = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * 17f);

        if (transform.position.x >= x)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.x <= -x)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.y >= y)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.y <= -y)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        //playerMove plasma = collision.collider.GetComponent<playerMove>();
        //Debug.Log("Test");
        //if (plasma != null)
        //{
        //    Destroy(this.gameObject);
        //}
    }
}