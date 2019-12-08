using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BounceSceneP2Shoot : MonoBehaviour
{
    public GameObject[] weaponsPrefab;

    int weaponType = 0;
    bool isWeapon1;
    bool isWeapon2;
    bool isWeapon3;
    bool isWeapon4;
    bool isWeapon5;

    GameObject ballClone;
    GameObject ballClone2;
    GameObject ballClone3;
    GameObject ballClone4;
    GameObject ballClone5;

    public Transform shotLoc;

    public float x = 10;
    public float y = 10;

    public int ballCount;
    public int ballCount2;
    public int ballCount3;
    public int ballCount4;
    public int ballCount5;

    public float shotStrength;

    public Text balls;
    public Text weapon2;
    public Text weapon3;
    public Text weapon4;
    public Text weapon5;

    public Transform player;
    public GameObject ind;
    float indyPos;
    float indxPos = 6.5f;

    float weapon4Timer;

    Rigidbody2D rb;
    float timer;

    void Awake()
    {
        shotStrength = 800;
    }
    void Start()
    {
        weapon4Timer = 0.1f;

        isWeapon1 = true;
        isWeapon2 = false;
        isWeapon3 = false;
        isWeapon4 = false;
        isWeapon5 = false;

        ballCount = 5;
        ballCount2 = 3;
        ballCount3 = 2;
        ballCount4 = 40;
        ballCount5 = 3;

        weapon2 = GameObject.FindGameObjectWithTag("BouncerP2").GetComponent<Text>();
        weapon3 = GameObject.FindGameObjectWithTag("PestsP2").GetComponent<Text>();
        weapon4 = GameObject.FindGameObjectWithTag("machineGunP2").GetComponent<Text>();
        weapon5 = GameObject.FindGameObjectWithTag("shotGunP2").GetComponent<Text>();
        balls = GameObject.FindGameObjectWithTag("RegularShotP2").GetComponent<Text>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BounceSceneHealthP2.playerHealth > 0)
        {
            if (weaponType == 0)
            {
                ind.transform.position = new Vector3(indxPos, 3.6f, -15);
                isWeapon1 = true;
                isWeapon2 = false;
                isWeapon3 = false;
                isWeapon4 = false;
                isWeapon5 = false;

            }

            if (weaponType == 1)
            {
                ind.transform.position = new Vector3(indxPos, 3.17f, -15);
                isWeapon1 = false;
                isWeapon2 = true;
                isWeapon3 = false;
                isWeapon4 = false;
                isWeapon5 = false;
            }

            if (weaponType == 2)
            {
                ind.transform.position = new Vector3(indxPos, 2.77f, -15);
                isWeapon1 = false;
                isWeapon2 = false;
                isWeapon3 = true;
                isWeapon4 = false;
                isWeapon5 = false;
            }

            if (weaponType == 3)
            {
                ind.transform.position = new Vector3(indxPos, 2.37f, -15);
                isWeapon1 = false;
                isWeapon2 = false;
                isWeapon3 = false;
                isWeapon4 = true;
                isWeapon5 = false;
            }

            if (weaponType == 4)
            {
                ind.transform.position = new Vector3(indxPos, 1.97f, -15);
                isWeapon1 = false;
                isWeapon2 = false;
                isWeapon3 = false;
                isWeapon4 = false;
                isWeapon5 = true;
            }

            Vector3 point = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            Vector3 axis = new Vector3(0, 0, 1);

            balls.text = "Shots: " + ballCount;
            weapon2.text = "bouncers:" + ballCount2;
            weapon3.text = "Pests: " + ballCount3;
            weapon4.text = "Machine gun: " + ballCount4;
            weapon5.text = "Shotgun: " + ballCount5;

            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                if (weaponType > 0)
                {
                    weaponType--;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                if (weaponType <= 3)
                {
                    weaponType++;
                }
            }

            if (Input.GetKey(KeyCode.Keypad1))
            {
                /*transform.Rotate(Vector3.forward);*/
                shotLoc.transform.RotateAround(point, axis, 5);
            }

            if (Input.GetKey(KeyCode.Keypad3))
            {
                shotLoc.transform.RotateAround(point, axis, -5);
            }


            if (Input.GetKeyDown(KeyCode.RightShift) && ballCount > 0 && isWeapon1 == true)
            {
                ballClone = Instantiate(weaponsPrefab[0], shotLoc.position, shotLoc.rotation) as GameObject;
                ballClone.GetComponent<Rigidbody2D>().AddForce(shotLoc.transform.up * shotStrength);
                ballCount--;
            }

            else if (Input.GetKeyDown(KeyCode.RightShift) && ballCount2 > 0 && isWeapon2 == true)
            {
                ballClone2 = Instantiate(weaponsPrefab[1], shotLoc.position, shotLoc.rotation) as GameObject;
                ballClone2.GetComponent<Rigidbody2D>().AddForce(shotLoc.transform.up * shotStrength);
                ballCount2--;
            }

            else if (Input.GetKeyDown(KeyCode.RightShift) && ballCount3 > 0 && isWeapon3 == true)
            {
                ballClone3 = Instantiate(weaponsPrefab[2], shotLoc.position, shotLoc.rotation) as GameObject;
                ballClone3.GetComponent<Rigidbody2D>().AddForce(shotLoc.transform.up * shotStrength);
                ballCount3--;
            }

            else if (Input.GetKey(KeyCode.RightShift) && ballCount4 > 0 && isWeapon4 == true)
            {
                weapon4Timer -= Time.deltaTime;
                if (weapon4Timer <= 0)
                {
                    ballClone4 = Instantiate(weaponsPrefab[3], shotLoc.position, shotLoc.rotation) as GameObject;
                    ballClone4.GetComponent<Rigidbody2D>().AddForce(shotLoc.transform.up * 1000);
                    ballCount4--;
                    weapon4Timer = 0.07f;
                }
            }

            else if (Input.GetKeyDown(KeyCode.RightShift) && ballCount5 > 0 && isWeapon5 == true)
            {
                for (int i = 0; i < 8; i++)
                {
                    float spread = Random.Range(-10, 10);
                    Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, 0, spread));
                    ballClone5 = Instantiate(weaponsPrefab[4], shotLoc.position, shotLoc.rotation * bulletRotation) as GameObject;
                    ballClone5.GetComponent<Rigidbody2D>().AddForce(ballClone5.transform.up * 700);
                }
                ballCount5--;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet3")
        {
            ballCount3++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "bullet2")
        {
            ballCount2++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "shot")
        {
            ballCount++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "bullet4")
        {
            ballCount4 += 20;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "bullet5")
        {
            ballCount5++;
            Destroy(other.gameObject);
        }
        //Destroy(ballClone.gameObject);
    }

}
