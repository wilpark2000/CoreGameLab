using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private BoxCollider2D bxc2D;
    [SerializeField] private LayerMask lm;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bxc2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }




        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * 20f;
        }

    }

   /* private bool IsGrounded()
    {
        RaycastHit2D rc = Physics2D.BoxCast(bxc2D.bounds.center, bxc2D.bounds.size, 0f, Vector2.down * 0.1f, lm);
        Debug.Log("ok m8");
        return rc.collider != null;
    }*/
}
