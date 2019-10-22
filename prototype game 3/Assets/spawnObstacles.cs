using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObstacles : MonoBehaviour
{
    public GameObject circlePrefab;
    public float respawnTime = Random.Range(0.2f,2);
    private Vector2 screenBounds;

    void Start()
    {
        StartCoroutine(circleWave());
    }
    void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(circlePrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x + 50, Random.Range(-screenBounds.y, screenBounds.y));
    }

    // Update is called once per frame
    IEnumerator circleWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy(); 
        }
    }
    
}
