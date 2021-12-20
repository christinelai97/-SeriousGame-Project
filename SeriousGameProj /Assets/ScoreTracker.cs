using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int staticScore = 0;
    [SerializeField] int totalAmountOfInteractions;
    public AudioSource levelComplete;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text sceneText;
    [SerializeField] TMP_Text playerText;

    public GameObject Player;
    public int NextLvl;
    public int calculatedInteractions=0;
    //int lastScoreUncalculated;
    // Start is called before the first frame update
    void Start()
    {
        //reset();
        //score = lastScoreUncalculated;

        score = PlayerPrefs.GetInt("score");
        staticScore = PlayerPrefs.GetInt("score");
        DisplayScore();
        DisplayScene();

    }

    // Update is called once per frame
    void Update()
    {
        if (score < 0)
        {
            score = 0;
        }
    }

    public void IncrementScore(int currentScore)
    {
  
        int lastScoreUncalculated = staticScore;
        //calculatedInteractions = lastScoreUncalculated + totalAmountOfInteractions;

        if (currentScore < 0)


            Debug.Log("Invalid; amount may not be less than zero.");
        else
    
            score += currentScore;

        PlayerPrefs.SetInt("score", score);
        DisplayScore();

        /**
        if (score == calculatedInteractions)
        {
            //levelComplete = GetComponent<AudioSource>();
            //AudioSource.PlayClipAtPoint(levelComplete.clip, transform.position);
            Invoke("nextScene", 2f);
        }
        **/
    }

    public void IncrementScore()
    {
        IncrementScore(1);
    }

    public void IncrementInteractions()
    {
        calculatedInteractions++;

        if (calculatedInteractions == totalAmountOfInteractions )
        {
            //levelComplete = GetComponent<AudioSource>();
            //AudioSource.PlayClipAtPoint(levelComplete.clip, transform.position);
            Invoke("nextScene", 2f);
        }
    }

    public void DisplayScore()
    {
        scoreText.text = "Score: " + score;

    }

    
    public void DisplayScene()
    {
        int firstLevelDisplayNum = 1;
        int secondLevelDisplayNum = 2;
        int thirdLevelDisplayNum = 3;


        int sceneNum = SceneManager.GetActiveScene().buildIndex;

        if (sceneNum == 1)
        {
            //sceneText.text = "Level " + level;
            sceneText.text = "Level: Home Sweet Home ";
        }
        if (sceneNum == 2)
        {
            sceneText.text = "Level: Bus Stop";
        }
        if (sceneNum == 3)
        {
            sceneText.text = "Level: Office";
        }
        if (sceneNum == 4)
        {
            sceneText.text = "Level: Groceries";
        }
        if (sceneNum == 5)
        {
            sceneText.text = "Level: Bus Stop";
        }
        if (sceneNum ==6)
        {
            sceneText.text = "Level: Home Sweet Home";
        }
    }
    

   
    public void nextScene()
    {
        SceneManager.LoadScene(NextLvl);
    }

    public void reset()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }
   

}