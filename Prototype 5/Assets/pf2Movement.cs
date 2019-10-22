using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pf2Movement : MonoBehaviour
{
    /*Rigidbody2D rb;*/
    // Start is called before the first frame update
    void Start()
    {


    }

    public void moveRight2()
    {
        transform.Rotate(-Vector3.forward * 250 * Time.deltaTime);
    }

    public void moveLeft2()
    {
        transform.Rotate(Vector3.forward * 250 * Time.deltaTime);
    }


    // Update is called once per frame
    void FixedUpdate()
    {

    }
}