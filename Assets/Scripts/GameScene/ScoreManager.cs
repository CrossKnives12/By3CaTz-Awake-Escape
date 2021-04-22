using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text hiScoreText;

    public float scoreCount; //Score counter
    public float hiScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    public GameObject EthanScore;
    private PlayerCollisions ScoreEthan;

    private float multiplier;
    private float MedicineBig = 20f;
    private float MedicineSmall = 10f;

    private bool scoreThis;

    // Use this for initialization
    void Start ()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }

        ScoreEthan = EthanScore.GetComponent<PlayerCollisions>();

        StartCoroutine(PillsScore());
    } 
	
	// Update is called once per frame
	void Update ()
    {
        if(scoreIncreasing && Time.timeScale == 1)
        {
           scoreCount += pointsPerSecond * multiplier ;
        }
         
        //Multiplier Formula
        if (scoreCount >= 1000 && scoreCount <= 1999)
        {
            multiplier = 1.1f;
        }
        else if (scoreCount >= 2000 && scoreCount <= 2999)
        {
            multiplier = 1.2f;
        }
        else if (scoreCount >= 3000 && scoreCount <= 3999)
        {
            multiplier = 1.3f;
        }
        else if (scoreCount >= 4000 && scoreCount <= 4999)
        {
            multiplier = 1.4f;
        }
        else if (scoreCount >= 5000)
        {
            multiplier = 1.5f;
        }
        else
        {
            multiplier = 1;
        }

        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }

        scoreText.text = "" + Mathf.Round (scoreCount) ;
        hiScoreText.text = "" + Mathf.Round (hiScoreCount) ; 
	}

    IEnumerator PillsScore()
    {
        yield return new WaitForSeconds(4);

        while (!scoreThis)
        {
            //Powerup Medicine Bonus
            if (ScoreEthan.isMedsBig == true)
            {
                scoreCount += MedicineBig;
            }

            if (ScoreEthan.isMedsSmall == true)
            {
                scoreCount += MedicineSmall;
            }

            yield return new WaitForSeconds(4);
        }


    }
}
