using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pf1Movement : MonoBehaviour
{
    /*Rigidbody2D rb;*/
    // Start is called before the first frame update
    void Start()
    {


    }

    public void moveRight()
    {
        transform.Rotate(-Vector3.forward * 250 * Time.deltaTime);
    }

    public void moveLeft()
    {
        transform.Rotate(Vector3.forward * 250 * Time.deltaTime);
    }


    // Update is called once per frame
    void FixedUpdate()
    {

    }
}

