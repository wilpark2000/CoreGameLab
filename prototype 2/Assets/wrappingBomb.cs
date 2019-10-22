using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrappingBomb : MonoBehaviour
{
    float max_x;
    float max_y;
    float min_x;
    float min_y;

    // Start is called before the first frame update
    void Start()
    {
        max_x = 186f;
        max_y = 31f;
        min_x = -63.7f;
        min_y = -27.1f;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= max_x)
        {
            transform.position = new Vector2(max_x, transform.position.y);
        }

        if (transform.position.x <= min_x)
        {
            transform.position = new Vector2(min_x, transform.position.y);
        }

        if (transform.position.y >= max_y)
        {
            transform.position = new Vector2(transform.position.x, max_y);
        }
        if (transform.position.y <= min_y)
        {
            transform.position = new Vector2(transform.position.x, min_y);
        }
    }
}
