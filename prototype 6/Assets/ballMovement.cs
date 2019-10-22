using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    
    public Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //transform.Translate(Vector2.up * 15f);

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.up * 2f);
        

    }
   

}
