using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drumAnim : MonoBehaviour
{
    public Animator anim;
    int playLoop;
    int timesPlayed;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        timesPlayed = 0;
        playLoop = Random.Range(1, 12);
    }

    // Update is called once per frame
    void Update()
    {
        if (timesPlayed < playLoop)
        {
            anim.SetTrigger("playAnimation");
            timesPlayed++;
        }
        else if (timesPlayed >= playLoop)
        {
            anim.SetTrigger("stopAnimation");
        }

        /*for (int i = 0; i < playLoop; i++)
        {
            anim.SetTrigger("playAnimation");
            timesPlayed++;
        }*/
    }
}
