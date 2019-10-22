using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject platform;
    public GameObject ball;
    float width;
    float height;
    Vector2 ScreenUnits;
    GameObject b;
    // Start is called before the first frame update
    void Start()
    {
        for (float i = -8; i <= 8; i += 3.5f) 
        {
            Instantiate(platform, new Vector2(i, -2), Quaternion.identity);
        }

        width = Screen.width;
        height = Screen.height;
        Vector2 ScreenUnits = Camera.main.ScreenToWorldPoint(new Vector3(width, height, 0));

        b = Instantiate(ball, new Vector2(Random.Range(-5, 5), 6), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (b.transform.position.x <= ScreenUnits.x * -1|| b.transform.position.x >= ScreenUnits.x) 
        {
            Destroy(b);
            b = Instantiate(ball, new Vector2(Random.Range(-5, 5), 6), Quaternion.identity);
        }
    }
}
