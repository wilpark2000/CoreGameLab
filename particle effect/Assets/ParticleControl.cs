using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    ParticleSystem p;
    SpriteRenderer s;
    void Start()
    {
        p = GetComponent<ParticleSystem>();
        s = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Boom()
    {
        s.enabled = false;
        p.Play();
        Destroy(this.gameObject, p.duration);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Boom();
    }
}
