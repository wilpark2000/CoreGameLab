using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneMovement : MonoBehaviour
{
    [SerializeField] private LayerMask lm;
    private PlayerOne playerOne;
    private Rigidbody2D rb;
    private bool jump = true;
    public GameObject objectRotate;

    int numberOfJumps;

    private void Awake()
    {
        playerOne = gameObject.GetComponent<PlayerOne>();
        rb = transform.GetComponent<Rigidbody2D>();
        numberOfJumps = 0;
    }

   
    void Update()
    {
        //if (Input.GetKey(KeyCode.Q))
        //    objectRotate.transform.Rotate(Vector3.forward);

        //if (Input.GetKey(KeyCode.E))
        //    objectRotate.transform.Rotate(Vector3.back);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (numberOfJumps > 0)
            {
                float jumpV = 20f;
                rb.velocity = Vector2.up * jumpV;
                numberOfJumps--;
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

        //else
        //{
        //    rb.velocity = new Vector2(0, rb.velocity.y);
        //}

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            numberOfJumps = 2;
            Debug.Log(numberOfJumps);
        }
    }

    //void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "Ground")
    //    {
    //        numberOfJumps--;
    //    }
    //}

    /*private bool IsGrounded()
    {
        RaycastHit2D rch = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, lm);
        return rch.collider != null;
    }*/
}
