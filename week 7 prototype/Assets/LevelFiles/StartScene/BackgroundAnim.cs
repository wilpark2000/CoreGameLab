using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnim : MonoBehaviour
{
    public GameObject polygons;
    GameObject polygon;
    float timer;
    float xpos;
    float ypos = -6.2f;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.5f;
        xpos = Random.Range(-9, 9);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 euler = transform.eulerAngles;
            euler.z = Random.Range(0f, 360f);
            transform.eulerAngles = euler;
            polygon = Instantiate(polygons, new Vector3(xpos, ypos, 20), Quaternion.Euler(0, 0, Random.Range(0, 360)));
            timer = Random.Range(0.5f, 0.8f);
            xpos = Random.Range(-9, 9);
        }
    }
}
