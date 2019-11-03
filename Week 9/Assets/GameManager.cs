using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string[] sentences;
    public Text dialogue;
    public float typeSpeed;

    int index;
    public GameObject continueButton;
    

    void Start()
    {
        index = 0;
        dialogue.text = "";
        StartCoroutine(TextTyper());
        continueButton.SetActive(false);

        //dialogue.text = sentences[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogue.text == sentences[index])
        {
            continueButton.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                ContinueDialogue();
            }
        }

        else
        {
            continueButton.SetActive(false);
        }
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    index++;
        //    if (index > sentences.Length - 1)
        //    {
        //        index = 0;
        //    }
        //    dialogue.text = sentences[index];
        //}
    }

    public void ContinueDialogue()
    {
        index++;
        if (index > sentences.Length - 1)
        {
            index = 0;
        }
        dialogue.text = "";
        StartCoroutine(TextTyper());
    }

    IEnumerator TextTyper()
    {
        foreach (char c in sentences[index].ToCharArray())
        {
            dialogue.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
}
