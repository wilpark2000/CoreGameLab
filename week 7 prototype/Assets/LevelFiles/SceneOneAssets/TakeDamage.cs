using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    int health;

    void Awake()
    {
        health = 100;
    }

    void Start()
    {
        health = 100;
        PlayerPrefs.SetFloat("playerHealth", health);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("playerHealth", health);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "weapon")
        {
            health -= 110;
            Destroy(other.gameObject);
        }
    }
}
