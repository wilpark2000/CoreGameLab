using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneShootP1 : MonoBehaviour
{
    float ballCount;
    public GameObject ball;
    GameObject ballClone;
    public Transform shotLoc;
    public float x = 10;
    public float y = 10;
    public Transform player;
    Rigidbody2D rb;
    float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        Vector3 axis = new Vector3(0, 0, 1);

        if (Input.GetKey(KeyCode.Q))
        {
            /*transform.Rotate(Vector3.forward);*/
            shotLoc.transform.RotateAround(point, axis, 5);
        }

        if (Input.GetKey(KeyCode.E))
        {
            shotLoc.transform.RotateAround(point, axis, -5);
        }

        if (Input.GetKeyDown(KeyCode.F) && ballCount > 0)
        {
            ballClone = Instantiate(ball, shotLoc.position, shotLoc.rotation) as GameObject;
            ballClone.GetComponent<Rigidbody2D>().AddForce(shotLoc.transform.up * 700);
            ballCount--;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "shot")
        {
            ballCount++;
            Destroy(other.gameObject);
        }
    }
}
