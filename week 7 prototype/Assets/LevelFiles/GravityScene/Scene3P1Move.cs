using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene3P1Move : MonoBehaviour
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
    public Transform grabLoc;

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

    float weapon4Timer;

    Rigidbody2D rb;
    float timer;

    private bool jump = true;
    int numberOfJumps;

    Animator anim;

    public bool isRotated;

    void Awake()
    {
        shotStrength = 800;
        isRotated = false;
    }
    void Start()
    {
        anim = GetComponent<Animator>();

        weapon4Timer = 0.1f;

        isWeapon1 = true;
        isWeapon2 = false;
        isWeapon3 = false;
        isWeapon4 = false;
        isWeapon5 = false;

        ballCount = 1;
        ballCount2 = 1;
        ballCount3 = 1;
        ballCount4 = 20;
        ballCount5 = 100;

        weapon2 = GameObject.FindGameObjectWithTag("BouncerP1").GetComponent<Text>();
        weapon3 = GameObject.FindGameObjectWithTag("PestsP1").GetComponent<Text>();
        weapon4 = GameObject.FindGameObjectWithTag("machineGunP1").GetComponent<Text>();
        weapon5 = GameObject.FindGameObjectWithTag("shotGunP1").GetComponent<Text>();
        balls = GameObject.FindGameObjectWithTag("RegularShotP1").GetComponent<Text>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (numberOfJumps > 0)
            {
                float jumpV = 17f;

                if (isRotated == false)
                {
                    rb.velocity = Vector2.up * jumpV;
                }
                if (isRotated == true)
                {
                    rb.velocity = Vector2.up * -jumpV;
                }
                numberOfJumps--;
            }
        }

        float speed = 5f;

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        if (weaponType == 0)
        {
            isWeapon1 = true;
            isWeapon2 = false;
            isWeapon3 = false;
            isWeapon4 = false;
            isWeapon5 = false;
        }

        if (weaponType == 1)
        {
            isWeapon1 = false;
            isWeapon2 = true;
            isWeapon3 = false;
            isWeapon4 = false;
            isWeapon5 = false;
        }

        if (weaponType == 2)
        {
            isWeapon1 = false;
            isWeapon2 = false;
            isWeapon3 = true;
            isWeapon4 = false;
            isWeapon5 = false;
        }

        if (weaponType == 3)
        {
            isWeapon1 = false;
            isWeapon2 = false;
            isWeapon3 = false;
            isWeapon4 = true;
            isWeapon5 = false;
        }

        if (weaponType == 4)
        {
            isWeapon1 = false;
            isWeapon2 = false;
            isWeapon3 = false;
            isWeapon4 = false;
            isWeapon5 = true;
        }

        Vector3 point = new Vector3(grabLoc.transform.position.x, grabLoc.transform.position.y, 0);
        Vector3 axis = new Vector3(0, 0, 1);
        grabLoc.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        balls.text = "Shot: " + ballCount;
        weapon2.text = "Bouncers:" + ballCount2;
        weapon3.text = "Pests: " + ballCount3;
        weapon4.text = "Machine gun: " + ballCount4;
        weapon5.text = "Shot gun: " + ballCount5;

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (weaponType > 0)
            {
                weaponType--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (weaponType <= 3)
            {
                weaponType++;
            }
        }

        if (Input.GetKey(KeyCode.Q))
        {
            /*transform.Rotate(Vector3.forward);*/
            shotLoc.transform.RotateAround(point, axis, 5);
        }

        if (Input.GetKey(KeyCode.E))
        {
            shotLoc.transform.RotateAround(point, axis, -5);
        }


        if (Input.GetKeyDown(KeyCode.F) && ballCount > 0 && isWeapon1 == true)
        {
            if (isRotated == true)
            {
                ballClone = Instantiate(weaponsPrefab[0], shotLoc.position, shotLoc.rotation) as GameObject;
                ballClone.GetComponent<Rigidbody2D>().AddForce(shotLoc.transform.up * shotStrength);
                ballClone.GetComponent<Rigidbody2D>().gravityScale = -2;
                ballCount--;
            }
            if (isRotated == false)
            {
                ballClone = Instantiate(weaponsPrefab[0], shotLoc.position, shotLoc.rotation) as GameObject;
                ballClone.GetComponent<Rigidbody2D>().AddForce(shotLoc.transform.up * shotStrength);
                ballClone.GetComponent<Rigidbody2D>().gravityScale = 2;
                ballCount--;
            }
        }

        else if (Input.GetKeyDown(KeyCode.F) && ballCount2 > 0 && isWeapon2 == true)
        {
            if (isRotated == true)
            {
                ballClone2 = Instantiate(weaponsPrefab[1], shotLoc.position, shotLoc.rotation) as GameObject;
                ballClone2.GetComponent<Rigidbody2D>().AddForce(shotLoc.transform.up * shotStrength);
                ballClone2.GetComponent<Rigidbody2D>().gravityScale = -4;
                ballCount2--;
            }

            if (isRotated == false)
            {
                ballClone2 = Instantiate(weaponsPrefab[1], shotLoc.position, shotLoc.rotation) as GameObject;
                ballClone2.GetComponent<Rigidbody2D>().AddForce(shotLoc.transform.up * shotStrength);
                ballClone2.GetComponent<Rigidbody2D>().gravityScale = 4;
                ballCount2--;
            }
        }

        else if (Input.GetKeyDown(KeyCode.F) && ballCount3 > 0 && isWeapon3 == true)
        {
            if (isRotated == true)
            {
                ballClone3 = Instantiate(weaponsPrefab[2], shotLoc.position, shotLoc.rotation) as GameObject;
                ballClone3.GetComponent<Rigidbody2D>().AddForce(shotLoc.transform.up * shotStrength);
                ballClone3.GetComponent<Rigidbody2D>().gravityScale = -3;
                ballCount3--;
            }
            if (isRotated == false)
            {
                ballClone3 = Instantiate(weaponsPrefab[2], shotLoc.position, shotLoc.rotation) as GameObject;
                ballClone3.GetComponent<Rigidbody2D>().AddForce(shotLoc.transform.up * shotStrength);
                ballClone3.GetComponent<Rigidbody2D>().gravityScale = 3;
                ballCount3--;
            }
        }

        else if (Input.GetKey(KeyCode.F) && ballCount4 > 0 && isWeapon4 == true)
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

        else if (Input.GetKeyDown(KeyCode.F) && ballCount5 > 0 && isWeapon5 == true)
        {
            //Vector3 dir = (shotLoc.transform.position - transform.position).normalized;
            //float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            numberOfJumps = 2;
            //Debug.Log(numberOfJumps);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "OGGround")
        {
            anim.SetBool("180 Rotate Bool", true);
            rb.gravityScale = -4;
            isRotated = true;
        }

        if (other.gameObject.tag == "Grav")
        {
            anim.SetBool("180 Rotate Bool", false);
            rb.gravityScale = 4;
            isRotated = false;
        }

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
    }
}