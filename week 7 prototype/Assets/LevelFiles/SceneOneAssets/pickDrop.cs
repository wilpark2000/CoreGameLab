using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickDrop : MonoBehaviour
{
    private bool inRange = false;
    public GameObject pickUp;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (inRange == true)
            {
                transform.position = pickUp.transform.position;
                inRange = false;
            }
        }

        if (Input.GetKey(KeyCode.F))
        {
            if (inRange == false)
            {
                transform.position = transform.position;
                rb.velocity = Vector2.up * 20f;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }
}
