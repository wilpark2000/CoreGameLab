using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Menu()
    {
        Destroy(GameObject.Find("Polygon"));
        Destroy(GameObject.Find("Polygon (1)"));
        SceneManager.LoadScene("StartScene");
    }
}
