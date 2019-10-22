using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelSpawn : MonoBehaviour
{
    public GameObject wheel;
    float timeStart;
    float timeUp;
    float timeBetweenSpawn;
    float timeDelay;
    float count;

    void Start()
    {
        timeBetweenSpawn = Random.Range(2f, 3f);
        timeDelay = Random.Range(4f,7f);
        
    }

    public void OnButtonRepeat()
    {
        timeStart = 0;
        timeUp = timeStart + Time.deltaTime;
        if (timeUp <= 20)
        {
            InvokeRepeating("SpawnWheel", timeBetweenSpawn, timeDelay);
        }

    }

    public void SpawnWheel()
    {
        
        Instantiate(wheel, new Vector2(Random.Range(-5.8f, -4.9f), 4f), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (timeUp >= 20f)
        {
            CancelInvoke();
        }

        if(transform.position.y <= -7)
        {
            Destroy(this.wheel);
        }
    }
}
