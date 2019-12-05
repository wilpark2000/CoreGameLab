using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon5 : MonoBehaviour
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "P1Goal" || other.gameObject.tag == "P2Goal" || other.gameObject.tag == "Football")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "shot" || other.gameObject.tag == "bullet2" || other.gameObject.tag == "bullet3" || other.gameObject.tag == "bullet4" || other.gameObject.tag == "bullet5")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "weapon" || other.gameObject.tag == "weapon2" || other.gameObject.tag == "weapon3" || other.gameObject.tag == "weapon4")
        {
            Destroy(this.gameObject);
        }
    }
}
