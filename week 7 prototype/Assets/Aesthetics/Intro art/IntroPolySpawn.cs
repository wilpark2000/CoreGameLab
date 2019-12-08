using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroPolySpawn : MonoBehaviour
{
    float Scenetimer = 7f;
    public GameObject polygons;
    GameObject polygon;
    float timer;
    float xpos = -11f;
    float ypos;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.5f;
        ypos = Random.Range(-9, 9);
    }

    // Update is called once per frame
    void Update()
    {
        Scenetimer -= Time.deltaTime;
        if (Scenetimer <= 0)
        {
            SceneManager.LoadScene("StartScene");
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 euler = transform.eulerAngles;
            euler.z = Random.Range(0f, 360f);
            transform.eulerAngles = euler;
            polygon = Instantiate(polygons, new Vector3(xpos, ypos, 20), Quaternion.Euler(0, 0, Random.Range(0, 360)));
            timer = Random.Range(0.05f, 0.1f);
            ypos = Random.Range(-7, 7);
        }
    }
}

