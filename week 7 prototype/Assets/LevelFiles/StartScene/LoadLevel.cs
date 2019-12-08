using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    List<string> levelSelect = new List<string>();

    float totalScoreP1;
    float totalScoreP2;
    int sceneSelect;
    public GameObject playerOne;
    public GameObject playerTwo;

    Text secondsTilNextMatch;
    Text playerWin;
    Text finalWin;
    Text p1Score;
    Text p2Score;

    public Scene currentScene;

    bool SampleScene = true;
    bool BounceScene = true;
    bool GravityScene = true;
    bool FallScene = true;
    bool FootBall = true;
    string sceneName;
    bool scenesLeft = true;

    float timer;
    string levelName;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Debug.Log(currentScene.name);

        if (currentScene.name == "StartScene")
        {
            levelSelect.Add("SampleScene" as string);
            levelSelect.Add("BounceScene" as string);
            levelSelect.Add("GravityScene" as string);
            levelSelect.Add("FallScene" as string);
            levelSelect.Add("FootBall" as string);
            Debug.Log(levelSelect.Count);
        }

        SampleScene = true;
        BounceScene = true;
        GravityScene = true;
        FallScene = true;
        FootBall = true;

        //if (currentScene.name == "BounceScene")
        //{
        //    BounceScene = false;
        //    levelSelect.Remove("BounceScene");
        //    secondsTilNextMatch.text = "";
        //    playerWin.text = "";
        //    timer = 5;
        //}

        //if (currentScene.name == "GravityScene")
        //{
        //    GravityScene = false;
        //    levelSelect.Remove("GravityScene");
        //    secondsTilNextMatch.text = "";
        //    playerWin.text = "";
        //    timer = 5;
        //}

        //if (currentScene.name == "FallScene")
        //{
        //    FallScene = false;
        //    levelSelect.Remove("FallScene");
        //    secondsTilNextMatch.text = "";
        //    playerWin.text = "";
        //    timer = 5;
        //}

        //if (currentScene.name == "FootBall")
        //{
        //    FootBall = false;
        //    levelSelect.Remove("FootBall");
        //    secondsTilNextMatch.text = "";
        //    playerWin.text = "";
        //    timer = 5;
        //}
    }

    void Start()
    {
        //secondsTilNextMatch = GameObject.Find("victoryText").GetComponent<Text>();
        //playerWin = GameObject.Find("win").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    { 
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Debug.Log(currentScene.name);

        if (BounceScene == false && SampleScene == false && GravityScene == false && FallScene == false && FootBall == false)
        {
            scenesLeft = false;
            Debug.Log("scenesLeft" + scenesLeft);
        }

        if (currentScene.name == "Tutorial")
        {
            Destroy(GameObject.Find("GameManager"));
        }

        if (currentScene.name == "SampleScene")
        {
            SampleScene = false;
            bool addedScore = false;
            float p1Health = PlayerPrefs.GetFloat("s1P1Health");
            float p2Health = PlayerPrefs.GetFloat("s1P1Health");

            secondsTilNextMatch = GameObject.Find("victoryText").GetComponent<Text>();
            playerWin = GameObject.Find("win").GetComponent<Text>();

            if (health.alive == true && Player2Health.alive == true)
            {
                secondsTilNextMatch.text = "";
                playerWin.text = "";
                timer = 5;
            }
            
            Debug.Log(levelSelect.Count);
            SampleScene = false;

            if (/*p1Health <= 90 || */health.alive == false)
            {
                timer -= Time.deltaTime;
                secondsTilNextMatch.text = "Player 2 wins!! ";
                playerWin.text = (Mathf.Round(timer)).ToString("0");
                if (timer <= 0)
                {
                    levelSelect.Remove("SampleScene");
                    if (scenesLeft == true)
                    {
                        if (health.killed == true)
                        {
                            if (addedScore == false)
                            {
                                totalScoreP2 += 50;
                                addedScore = true;
                            }
                        }
                        if (health.fell == true)
                        {
                            if (addedScore == false)
                            {
                                totalScoreP2 += 75;
                                addedScore = true;
                            }
                        }
                        DontDestroyOnLoad(this.gameObject);
                        SceneManager.LoadScene(levelSelect[Random.Range(0, levelSelect.Count)]);
                    }
                    if (scenesLeft == false)
                    {
                        if (health.killed == true)
                        {
                            if (addedScore == false)
                            {
                                totalScoreP2 += 50;
                                addedScore = true;
                            }
                        }
                        if (health.fell == true)
                        {
                            if (addedScore == false)
                            {
                                totalScoreP2 += 50;
                                addedScore = true;
                            }
                        }
                        Destroy(this.gameObject);
                        SceneManager.LoadScene("End");
                    }
                }
            }

            else if (/*p2Health <= 90 || */Player2Health.alive == false)
            {
                timer -= Time.deltaTime;
                secondsTilNextMatch.text = "Player 1 wins!! ";
                playerWin.text = (Mathf.Round(timer)).ToString("0");
                if (timer <= 0)
                {
                    if (scenesLeft == true)
                    {
                        levelSelect.Remove("SampleScene");
                        if (Player2Health.killed == true)
                        {
                            if (addedScore == false)
                            {
                                totalScoreP1 += 50;
                                addedScore = true;
                            }
                        }
                        if (Player2Health.fell == true)
                        {
                            if (addedScore == false)
                            {
                                totalScoreP1 += 75;
                                addedScore = true;
                            }
                        }
                        DontDestroyOnLoad(this.gameObject);
                        SceneManager.LoadScene(levelSelect[Random.Range(0, levelSelect.Count)]);
                    }
                    if (scenesLeft == false)
                    {
                        if (Player2Health.killed == true)
                        {
                            if (addedScore == false)
                            {
                                totalScoreP1 += 50;
                                addedScore = true;
                            }
                        }
                        if (Player2Health.fell == true)
                        {
                            if (addedScore == false)
                            {
                                totalScoreP1 += 75;
                                addedScore = true;
                            }
                        }
                        Destroy(this.gameObject);
                        SceneManager.LoadScene("End");
                    }
                }
            }
        }

        if (currentScene.name == "BounceScene")
        {
            BounceScene = false;
            bool addedScore = false;
            secondsTilNextMatch = GameObject.Find("victoryText").GetComponent<Text>();
            playerWin = GameObject.Find("win").GetComponent<Text>();

            if (BounceSceneHealth.playerHealth > 0 && BounceSceneHealthP2.playerHealth > 0)
            {
                secondsTilNextMatch.text = "";
                playerWin.text = "";
                timer = 5;
            }

            if (BounceSceneHealth.playerHealth <= 0)
            {
                timer -= Time.deltaTime;
                secondsTilNextMatch.text = "Player 2 wins!! ";
                playerWin.text = (Mathf.Round(timer)).ToString("0");

                if (timer <= 0)
                {
                    if (scenesLeft == true)
                    {
                        DontDestroyOnLoad(this.gameObject);
                        BounceScene = false;
                        if (addedScore == false)
                        {
                            totalScoreP2 += 60;
                            addedScore = true;
                        }
                        levelSelect.Remove("BounceScene");
                        SceneManager.LoadScene(levelSelect[Random.Range(0, levelSelect.Count)]);
                    }
                    if (scenesLeft == false)
                    {
                        if (addedScore == false)
                        {
                            totalScoreP2 += 60;
                            addedScore = true;
                        }
                        Destroy(this.gameObject);
                        SceneManager.LoadScene("End");
                    }
                }
            }

            else if (BounceSceneHealthP2.playerHealth <= 0)
            {
                timer -= Time.deltaTime;

                secondsTilNextMatch.text = "Player 1 wins!! ";
                playerWin.text = (Mathf.Round(timer)).ToString("0");
                if (timer <= 0)
                {
                    if (scenesLeft == true)
                    {
                        DontDestroyOnLoad(this.gameObject);
                        BounceScene = false;
                        if (addedScore == false)
                        {
                            totalScoreP1 += 60;
                            addedScore = true;
                        }
                        levelSelect.Remove("BounceScene");
                        SceneManager.LoadScene(levelSelect[Random.Range(0, levelSelect.Count)]);
                    }
                    if (scenesLeft == false)
                    {
                        if (addedScore == false)
                        {
                            totalScoreP1 += 60;
                            addedScore = true;
                        }
                        Destroy(this.gameObject);
                        SceneManager.LoadScene("End");
                    }
                }
            }
        }

        if (currentScene.name == "GravityScene")
        {
            GravityScene = false;
            bool addedScore = false;
            secondsTilNextMatch = GameObject.Find("victoryText").GetComponent<Text>();
            playerWin = GameObject.Find("win").GetComponent<Text>();

            if (GravHealth.playerHealth > 0 && GravHealthP2.playerHealth > 0)
            {
                secondsTilNextMatch.text = "";
                playerWin.text = "";
                timer = 5;
            }

            
            if (GravHealth.playerHealth <= 0)
            {
                timer -= Time.deltaTime;
                secondsTilNextMatch.text = "Player 2 wins!! ";
                playerWin.text = (Mathf.Round(timer)).ToString("0");
                if (timer <= 0)
                {
                    if (scenesLeft == true)
                    {
                        GravityScene = false;
                        DontDestroyOnLoad(this.gameObject);
                        if (addedScore == false)
                        {
                            totalScoreP2 += 60;
                            addedScore = true;
                        }
                        levelSelect.Remove("GravityScene");
                        SceneManager.LoadScene(levelSelect[Random.Range(0, levelSelect.Count)]);
                    }
                    if (scenesLeft == false)
                    {
                        if (addedScore == false)
                        {
                            totalScoreP2 += 60;
                            addedScore = true;
                        }
                        Destroy(this.gameObject);
                        SceneManager.LoadScene("End");
                    }
                }
            }

            else if (GravHealthP2.playerHealth <= 0)
            {
                timer -= Time.deltaTime;
                secondsTilNextMatch.text = "Player 1 wins!! ";
                playerWin.text = (Mathf.Round(timer)).ToString("0");
                if (timer <= 0)
                {
                    if (scenesLeft == true)
                    {
                        GravityScene = false;
                        DontDestroyOnLoad(this.gameObject);
                        if (addedScore == false)
                        {
                            totalScoreP1 += 60;
                            addedScore = true;
                        }
                        levelSelect.Remove("GravityScene");
                        SceneManager.LoadScene(levelSelect[Random.Range(0, levelSelect.Count)]);
                    }
                    if (scenesLeft == false)
                    {
                        if (addedScore == false)
                        {
                            totalScoreP1 += 60;
                            addedScore = true;
                        }
                        Destroy(this.gameObject);
                        SceneManager.LoadScene("End");
                    }
                }
            }
        }

        if (currentScene.name == "FallScene")
        {
            FallScene = false;
            bool addedScore = false;
            secondsTilNextMatch = GameObject.Find("victoryText").GetComponent<Text>();
            playerWin = GameObject.Find("win").GetComponent<Text>();

            levelSelect.Remove("FallScene");
            if (SceneLoader.p1Out == false && SceneLoader.p2Out == false)
            {
                secondsTilNextMatch.text = "";
                playerWin.text = "";
                timer = 5;
            }

            if (SceneLoader.p1Out == true)
            {
                timer -= Time.deltaTime;
                secondsTilNextMatch.text = "Player 2 wins!! ";
                playerWin.text = (Mathf.Round(timer)).ToString("0");
                if (timer <= 0)
                {
                    if (scenesLeft == true)
                    {
                        DontDestroyOnLoad(this.gameObject);
                        FallScene = false;
                        if (addedScore == false)
                        {
                            totalScoreP2 += 60;
                            addedScore = true;
                        }
                        levelSelect.Remove("FallScene");
                        SceneManager.LoadScene(levelSelect[Random.Range(0, levelSelect.Count)]);
                    }
                    if (scenesLeft == false)
                    {
                        if (addedScore == false)
                        {
                            totalScoreP2 += 60;
                            addedScore = true;
                        }
                        Destroy(this.gameObject);
                        SceneManager.LoadScene("End");
                    }
                }
            }

            else if (SceneLoader.p2Out == true)
            {
                timer -= Time.deltaTime;
                secondsTilNextMatch.text = "Player 1 wins!! ";
                playerWin.text = (Mathf.Round(timer)).ToString("0");
                if (timer <= 0)
                {
                    if (scenesLeft == true)
                    {
                        DontDestroyOnLoad(this.gameObject);
                        FallScene = false;
                        if (addedScore == false)
                        {
                            totalScoreP1 += 60;
                            addedScore = true;
                        }
                        levelSelect.Remove("FallScene");
                        SceneManager.LoadScene(levelSelect[Random.Range(0, levelSelect.Count)]);
                    }
                    if (scenesLeft == false)
                    {
                        if (addedScore == false)
                        {
                            totalScoreP1 += 60;
                            addedScore = true;
                        }
                        Destroy(this.gameObject);
                        SceneManager.LoadScene("End");
                    }
                }
            }
        }

        if (currentScene.name == "FootBall")
        {
            FootBall = false;
            bool addedScore = false;
            secondsTilNextMatch = GameObject.Find("victoryText").GetComponent<Text>();
            playerWin = GameObject.Find("win").GetComponent<Text>();

            if (ScoreManage.p2Win == false && ScoreManage.p1Win == false && ScoreManage.tie == false) 
            {
                secondsTilNextMatch.text = "";
                playerWin.text = "";
                timer = 5;
            }

                if (ScoreManage.p2Win == true)
            {
                timer -= Time.deltaTime;
                secondsTilNextMatch.text = "Player 2 wins!! ";
                playerWin.text = (Mathf.Round(timer)).ToString("0");
                if (timer <= 0)
                {
                    if (scenesLeft == true)
                    {
                        levelSelect.Remove("FootBall");
                        FootBall = false;
                        if (addedScore == false)
                        {
                            totalScoreP2 += (40 + 5 * ScoreManage.scoreDif);
                            addedScore = true;
                        }
                        DontDestroyOnLoad(this.gameObject);
                        SceneManager.LoadScene(levelSelect[Random.Range(0, levelSelect.Count)]);
                    }
                    if (scenesLeft == false)
                    {
                        if (addedScore == false)
                        {
                            totalScoreP2 += (40 + 5 * ScoreManage.scoreDif);
                            addedScore = true;
                        }
                        Destroy(this.gameObject);
                        SceneManager.LoadScene("End");
                    }
                }
            }

            else if (ScoreManage.p1Win == true)
            {
                timer -= Time.deltaTime;
                secondsTilNextMatch.text = "Player 1 wins!! ";
                playerWin.text = (Mathf.Round(timer)).ToString("0");
                if (timer <= 0)
                {
                    if (scenesLeft == true)
                    {
                        levelSelect.Remove("FootBall");
                        FootBall = false;
                        if (addedScore == false)
                        {
                            totalScoreP1 += (40 + 5 * ScoreManage.scoreDif);
                            addedScore = true;
                        }
                        DontDestroyOnLoad(this.gameObject);
                        SceneManager.LoadScene(levelSelect[Random.Range(0, levelSelect.Count)]);
                    }
                    if (scenesLeft == false)
                    {
                        if (addedScore == false)
                        {
                            totalScoreP1 += (40 + 5 * ScoreManage.scoreDif);
                            addedScore = true;
                        }
                        Destroy(this.gameObject);
                        SceneManager.LoadScene("End");
                    }
                }
            }

            else if (ScoreManage.tie == true)
            {
                timer -= Time.deltaTime;
                secondsTilNextMatch.text = "It's a tie!";
                playerWin.text = (Mathf.Round(timer)).ToString("0");
                if (timer <= 0)
                {
                    if (scenesLeft == true)
                    {
                        levelSelect.Remove("FootBall");
                        FootBall = false;
                        DontDestroyOnLoad(this.gameObject);
                        SceneManager.LoadScene(levelSelect[Random.Range(0, levelSelect.Count)]);
                    }
                    if (scenesLeft == false)
                    {
                        Destroy(this.gameObject);
                        SceneManager.LoadScene("End");
                    }
                }
            }
        }


        if (currentScene.name == "end")
        {
            finalWin = GameObject.Find("finalWin").GetComponent<Text>();
            p1Score = GameObject.Find("p1Score").GetComponent<Text>();
            p2Score = GameObject.Find("p2Score").GetComponent<Text>();

            if (totalScoreP1 > totalScoreP2)
            {
                finalWin.text = "Player 1 Wins!";
            }
            if (totalScoreP1 < totalScoreP2)
            {
                finalWin.text = "Player 2 Wins!";
            }
            if (totalScoreP1 == totalScoreP2)
            {
                finalWin.text = "Tie";
            }

            p1Score.text = "" + totalScoreP1;
            p2Score.text = "" + totalScoreP2;
        }

        PlayerPrefs.SetFloat("p1TotalScore", totalScoreP1);
        PlayerPrefs.SetFloat("p2TotalScore", totalScoreP2);
    }

    public void LoadChallenge()
    {
        DontDestroyOnLoad(this.gameObject);
        Destroy(playerOne.gameObject);
        Destroy(playerTwo.gameObject);
        SceneManager.LoadScene(levelSelect[Random.Range(0, levelSelect.Count)]);
    }

    public void LoadTutorial()
    {
        Destroy(GameObject.Find("GameManager"));
        DontDestroyOnLoad(playerOne.gameObject);
        DontDestroyOnLoad(playerTwo.gameObject);
        SceneManager.LoadScene("Tutorial");
    }
}
