using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestsSpawner : MonoBehaviour
{
    public GameObject pests;
    GameObject pestsPrefab;
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
        for (int i = 0; i < 5; i++)
        {
            pestsPrefab = Instantiate(pests, new Vector2(transform.position.x + 0.1f*i, transform.position.y + 0.1f*i) , transform.rotation);
            pestsPrefab = Instantiate(pests, new Vector2(transform.position.x + -0.1f * i, transform.position.y + 0.1f * i), transform.rotation);
            pestsPrefab.GetComponent<Rigidbody2D>().AddForce(transform.up * 35);
        }
    }
}
