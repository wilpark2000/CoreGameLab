using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class followPlayer : MonoBehaviour
{
    public GameObject player;
    public Text timerValue;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 5f;
        timerValue.text = "Don't Let the Square Catch You!";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 5)
        {
            timerValue.text = "" + timer;
        }

        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = -20;
        player.transform.position = pz;

        if(timer <= 0)
        {
            SceneManager.LoadScene("End");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            timer -= Time.deltaTime;
            
        }
    }
}
