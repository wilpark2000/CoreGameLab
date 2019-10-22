using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brokenWheel : MonoBehaviour
{
    public GameObject wheel;
    float timeStart;
    float timeUp;
    float timeBetweenSpawn;
    float timeDelay;
    float count;

    void Start()
    {
        timeBetweenSpawn = Random.Range(6f, 9f);
        timeDelay = Random.Range(7f, 10f);
        count = 0;
    }

    public void OnButtonRepeat()
    {
        timeStart = 0;
        timeUp = timeStart + Time.deltaTime;
        InvokeRepeating("SpawnWheel", timeBetweenSpawn, timeDelay);

    }

    public void SpawnWheel()
    {
        count++;
        Instantiate(wheel, new Vector2(Random.Range(-5.8f, -4.9f), 5f), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y <= -7)
        {
            Destroy(this.wheel);
        }
    }
}
