using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    public Text text;
    string up = "asdfghty";
    string down = "qwerui";
    string left = "opjklm";
    string right = "zxcvbn";
    int count = 0;
    int ransec = 20;
    int ss;
    char dick;
    string dick1;
    KeyCode dick3;
    //public KeyCode moveUp;

   


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //ss = up.Length;
       // dick = up[Random.Range(0, ss)];
        //dick1 = "" + dick;
        //text.text = dick1;
        
    }

    void Update()

    {
        

        //count++;


       // if (count == ransec) {
            //count = 0;
            //dick = up[Random.Range(0, ss)];
            //dick1 = "" + dick;

            
            //text.text = dick1;
            
           // ransec = Random.Range(5 *60, 16*60);
            
        //}
        //dick3 = (KeyCode)System.Enum.Parse(typeof(KeyCode), "dick1");

        if (Input.GetKeyDown(KeyCode.G))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(down))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(left))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(right))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        
    }
}
    