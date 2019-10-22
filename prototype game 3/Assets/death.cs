using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    public int playerHealth;
    int damage = 1;
    public Text text;
    public GameObject circle;
    string st = "playerHealth";
    public float distance;



    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 3;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
       playerHealth -= damage;

      }
    }
    void Update()
    {
        var distance = Vector2.Distance(transform.position, circle.transform.position);

        if (distance <= 5)
        {
            SceneManager.LoadScene("You Died");
        }
        //text.text = playerHealth;
        //if (playerHealth == 0)
        //{
        //SceneManager.LoadScene("You Died");
        //}
    }
}
