using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomNumbers : MonoBehaviour
{
    public GameObject TextBox;
    public int TheNumber;


    // Start is called before the first frame update
    public void RandomGenerate()
    {
        TheNumber = Random.Range(1, 10);
        TextBox.GetComponent<Text>().text = "" + TheNumber;
    }
  
    
}
    