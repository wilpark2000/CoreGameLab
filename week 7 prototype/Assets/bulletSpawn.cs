using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpawn : MonoBehaviour
{
    public float Timer;
    public GameObject bullets;
    GameObject bulletClone;
    float xpos;
    float ypos;

    void Start()
    {
        Timer = Random.Range(10f, 17f);

        xpos = Random.Range(-5, 5);
        ypos = 6;
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            bulletClone = Instantiate(bullets, new Vector2(xpos,ypos), transform.rotation) as GameObject;
            Timer = Random.Range(10f, 17f);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}