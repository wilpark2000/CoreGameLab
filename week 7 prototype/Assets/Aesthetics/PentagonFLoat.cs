using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentagonFLoat : MonoBehaviour
{
    float yAdd;
    float angleAdd;
    float scale;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        yAdd = Random.Range(0.009f, 0.019f);
        angleAdd = Random.Range(-0.14f, 0.14f);
        scale = Random.Range(0.4f, 4f);
        transform.localScale = new Vector3(scale, scale, 0);
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.6f, 0.8f), Random.Range(0.84f, 1f), Random.Range(0.83f, 0.97f), Random.Range(0.08f, 0.46f));
    }

    // Update is called once per frame
    void Update()
    { 
        if (transform.position.y >= 7)
        {
            Destroy(this.gameObject);
        }
        transform.position = new Vector3(transform.position.x + 0.0008f, transform.position.y + yAdd, transform.position.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 120), Time.deltaTime * angleAdd);
    }
}
