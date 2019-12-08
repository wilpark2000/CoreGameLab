using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManage : MonoBehaviour
{
    public GameObject anim;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 2.8f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            anim.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
