using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePlayer : MonoBehaviour
{
    public GameObject bullet_p;
    public Transform shotLoc;

    void Start()
    {

    }


    void Update()
    {
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
        transform.up = direction;




        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet_p, shotLoc.position, shotLoc.rotation);
        }
    }
}

