using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public float Timer;
    public GameObject demons;
    GameObject demonClone;

    void Start()
    {
        Timer = Random.Range(2f, 7f);
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            demonClone = Instantiate(demons, transform.position, transform.rotation) as GameObject;
            Timer = Random.Range(2f, 6f);
        }

    }
}

