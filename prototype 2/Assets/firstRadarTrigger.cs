using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class firstRadarTrigger : MonoBehaviour
{
    AudioSource firstRadar;
    public AudioClip radarSound;
    public GameObject bomb;
    public Transform distance1;
    public float distance;

    private void Start()
    {
        //distance = Vector2 Bomb.transform.position
        firstRadar = GetComponent<AudioSource>();
        bomb = gameObject.GetComponent<GameObject>();
        //firstRadar.Play();
        
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
        //if(radarSound != null)
        //{
            //firstRadar.Play();
        //}
    //}

    void Update()
    {
        var distance1 = Vector2.Distance(transform.position, bomb.transform.position);
        print("distance" + distance1);

        if (distance1 <= 10f)
        {
            firstRadar.Play();
        }
        if (distance1 >= 10f)
        {
            firstRadar.Stop();
        }
    }
}
