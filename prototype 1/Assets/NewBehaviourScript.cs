using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public int RandomNumber;
    public GameObject TextBox;
    int rerandomize;
    // Start is called before the first frame update
    void Start()
    {
        RandomNumber = Random.Range(1, 11);
        TextBox.GetComponent<Text>().text = "" + RandomNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (rerandomize % 1800 == 0) {
            RandomNumber = Random.Range(1, 11);
            TextBox.GetComponent<Text>().text = "" + RandomNumber;
        }   

        rerandomize++;
    }
}
