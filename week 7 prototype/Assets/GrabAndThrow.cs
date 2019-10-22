using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndThrow : MonoBehaviour
{
    public bool grab;
    RaycastHit2D hit;
    public float distance = 0.5f;
    public Transform holdPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(!grab)
            {
                Physics2D.queriesStartInColliders = false;
                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

                if(hit.collider != null)
                {
                    grab = true;
                }
            }
            else
            {

            }

        }

        if(grab)
        {
            hit.collider.gameObject.transform.position = holdPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
       /* Gizmos.DrawLine()*/
    }
}
