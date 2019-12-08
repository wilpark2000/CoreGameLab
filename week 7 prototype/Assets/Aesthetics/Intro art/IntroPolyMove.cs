using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroPolyMove : MonoBehaviour
{
    float xAdd;
    float angleAdd;
    float scale;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        xAdd = Random.Range(0.09f, 0.13f);
        angleAdd = Random.Range(-1f, 1f);
        scale = Random.Range(0.4f, 4f);
        transform.localScale = new Vector3(scale, scale, 0);
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.7f, 1f), Random.Range(0.7f, 1f), Random.Range(0.1f, 0.35f), Random.Range(0.2f, 0.7f));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 11)
        {
            Destroy(this.gameObject);
        }
        transform.position = new Vector3(transform.position.x + xAdd, transform.position.y, transform.position.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 120), Time.deltaTime * angleAdd);
    }
}


