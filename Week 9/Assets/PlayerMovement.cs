using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    float speed = 2.5f;
    int coinCount;
    public Slider coinNumber;
    float timer;

    List<GameObject> coins = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        timer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        coinNumber.value = coinCount;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            collision.gameObject.SetActive(false);
            coins.Add(collision.gameObject);

            coinCount++;
            coinNumber.value = coinCount;
        }

        if (collision.gameObject.tag == "Patrol")
        {
            coinCount--;
            coinNumber.value = coinCount;

            if (coins.Count > 0)
            {
                int randomCoin = Random.Range(0, coins.Count);
                coins[randomCoin].gameObject.SetActive(true);
                coins.Remove(coins[randomCoin]);
            }

        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (coins.Count > 0)
            {
                int randomCoin = Random.Range(0, coins.Count);
                coins[randomCoin].gameObject.SetActive(true);
                coins.Remove(coins[randomCoin]);

                coinCount--;
                coinNumber.value = coinCount;
            }

            timer = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GuardMovement.isChasing = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GuardMovement.isChasing = false;
    }
}
