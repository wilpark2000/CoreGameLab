using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    public float playerHealth;
    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
        healthBar = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("End");
        }

        healthBar.value = playerHealth;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "weapon")
        {
            playerHealth -= 20;

        }
    }
}
