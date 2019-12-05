using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 14 || transform.position.x <= -14)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.y >= 10 || transform.position.y <= -10)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
