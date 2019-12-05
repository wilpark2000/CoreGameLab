using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAnim : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "OGGround")
        {
            anim.SetBool("Rotate", true);
        }

        if (other.gameObject.tag == "Grav")
        {
            anim.SetBool("Rotate", false);
        }
    }
}
