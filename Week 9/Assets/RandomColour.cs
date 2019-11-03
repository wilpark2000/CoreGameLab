using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColour : MonoBehaviour
{
    Color[] colours = new Color[] { Color.red, Color.blue, Color.green };
    
    void Start()
    {
        StartCoroutine(ThreeColourChange());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ThreeColourChange()
    {
        foreach (Color c in colours)
        {
            GetComponent<SpriteRenderer>().material.color = c;
            yield return new WaitForSeconds(3);
        }

        //Same thing
        //for (int i = 0; i < colours.Length; i++)
        //{
        //    GetComponent<SpriteRenderer>().material.color = colours[i];
        //    yield return new WaitForSeconds(3);
        //}
    }

    IEnumerator AutoColourChange()
    {
        while (true)
        {
            GetComponent<SpriteRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            yield return new WaitForSeconds(1);
        }
    }
}
