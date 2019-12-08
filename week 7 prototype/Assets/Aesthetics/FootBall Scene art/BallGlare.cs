using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGlare : MonoBehaviour
{
    public Transform ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(ball.transform.position.x + 0.0681f, ball.transform.position.y + 0.154f, ball.transform.position.z - 1);
    }
}
