using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleRespawn : MonoBehaviour
{
    public GameObject circlePrefab;
    private Vector2 screenBounds;
    bool gone = false;


    void Start()
    {
        GameObject a = Instantiate(circlePrefab) as GameObject;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    private void Update()
    {
        GameObject a = Instantiate(circlePrefab) as GameObject;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        if (circlePrefab.transform.position.x >= 9)
        {
            a.transform.position = new Vector2(screenBounds.y + 3, Random.Range(-screenBounds.x, screenBounds.x));
        }

        if (circlePrefab.transform.position.x <= -9)
        {
            a.transform.position = new Vector2(screenBounds.y + 3, Random.Range(-screenBounds.x, screenBounds.x));
        }
        if (circlePrefab.transform.position.y <= -6)
        {
            a.transform.position = new Vector2(screenBounds.y + 3, Random.Range(-screenBounds.x, screenBounds.x));
        }

       
        
        

    }
}
