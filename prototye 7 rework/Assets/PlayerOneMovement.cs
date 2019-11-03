using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneMovement : MonoBehaviour
{
    [SerializeField] private LayerMask lm;
    
    private Rigidbody2D rb;
    private bool jump = true;
    public GameObject objectRotate;

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jump == true)
            {
                float jumpV = 10f;
                rb.velocity = Vector2.up * jumpV;
                jump = false;
            }
        }

        float speed = 5f;

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

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "platform")
        {
            jump = true;
        }
    }
}
