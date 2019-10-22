using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class totalKillCount : MonoBehaviour
{
    public Text killsCommittedText;

    void Start()
    {

        killsCommittedText.text = PlayerPrefs.GetInt("killsCommitted").ToString();

    }

    




}