using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public float Timer;
    public float timer2;
    public GameObject demons;
    public GameObject[] demonPrefabs;
    GameObject demonClone;
    float randomMin;
    float randomMax;
    int kills;

    void Start()
    {
        Timer = Random.Range(3, 6);
        timer2 = Random.Range(6, 8.5f);
        randomMin = 3.5f;
        randomMax = 6f;
    }

    void Update()
    {
        kills = (int)PlayerPrefs.GetInt("killsCommitted");
        Timer -= Time.deltaTime;
        if (Timer <= 0 && kills <= 25)
        {
            demonClone = Instantiate(demons, transform.position, transform.rotation) as GameObject;
            Timer = Random.Range(randomMin, randomMax);
        }

        if (Timer <= 0 && kills <= 50 && kills >= 26)
        {
            demonClone = Instantiate(demons, transform.position, transform.rotation) as GameObject;
            Timer = Random.Range(5.5f, 7f);
        }

        timer2 -= Time.deltaTime;
        if (timer2 <= 0 && kills <= 50 && kills >= 26)
        {
            demonClone = Instantiate(demonPrefabs[1], transform.position, Quaternion.identity) as GameObject;
            timer2 = Random.Range(7, 9f);
        }
    }
}

