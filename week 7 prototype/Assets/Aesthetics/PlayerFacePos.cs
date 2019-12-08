using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFacePos : MonoBehaviour
{
    public GameObject shotLoc;
    public float size;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shotLoc.transform.localPosition.x >= 0)
        {
            transform.localScale = new Vector3(size, transform.localScale.y, transform.localScale.z);
        }
        else if (shotLoc.transform.localPosition.x < 0)
        {
            transform.localScale = new Vector3(-size, transform.localScale.y, transform.localScale.z);
        }
    }
}
