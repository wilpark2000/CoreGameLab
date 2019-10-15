using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class loadLevel : MonoBehaviour
{
    public Button button;
    public Text timerValue;
    public Slider slider;
    void Start()
    {
        timerValue = GetComponent<Text>();
        slider = GetComponent<Slider>();
        button = GetComponent<Button>();
        GameObject.Find("Button").GetComponentInChildren<Text>().text = "Select Value With the Slider";
        PlayerPrefs.SetInt("timerValue", (int)slider.value);


    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value > 0)
        {
            GameObject.Find("Button").GetComponentInChildren<Text>().text = "" + slider.value;
        }

    }

    public void StartLevel()
    {
        SceneManager.LoadScene("StartScene");
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("timerValue", (int)slider.value); 
    }


}
