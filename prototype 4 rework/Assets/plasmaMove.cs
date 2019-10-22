using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plasmaMove : MonoBehaviour
{
    float x = 30;
    float y = 20;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * 25f);

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
        enemyFollow plasma = collision.collider.GetComponent<enemyFollow>();
        Debug.Log("Test");
        if (plasma != null)
        {
            Destroy(this.gameObject);

        }
    }


}
