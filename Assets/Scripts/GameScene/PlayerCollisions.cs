using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//false == fade in
//true == fade out

public class PlayerCollisions : MonoBehaviour {

    public float nightmareCounter = 0;
    public float minusPerSecond;
    public float nightmareTimeCounter = 6;

    private bool isNightmareStart = false;
    public bool FadeNormal = false;
    public bool FadeVision1 = false;
    public bool FadeVision2 = false;
    
    public bool isVision1 = false;
    public bool isVision2 = false;
    public bool isVision3 = false;
    public float isVisionSpawnCount = 0;
    public float visionPerSecond;
    public float visionTimeCounter = 10;

    private int flyCounter = 0;
    private bool flyAfterEffect = false;
    public float descendPerSecond;
    public float descendTimeCounter = 3;
    private bool isLanding = false;

    public bool isFly = false;
    private bool isInvincibility = false;
    public bool isPowerups = false;
    public float powerupsPerSecond;
    public float powerupsTimeCounter = 10;

    public bool isSprint = false;
    public float sprintPerSecond;
    public float sprintTimeCounter = 15;

    public bool isNormal = true;

    public bool isMedsBig = false;
    public float BigMedsPerSeconds;
    public float BigMedsTimeCounter = 5;
    public bool isMedsSmall = false;
    public float SmallMedsPerSeconds;
    public float SmallMedsTimeCounter = 5;

    //public bool isDeath = false;

    ObstacleMovement om;
    ParralaxBG pbg;

    // Use this for initialization
    void Start ()
    {
        om = GetComponent<ObstacleMovement>();
        pbg = GetComponent<ParralaxBG>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //For the Nightmare
		if(nightmareCounter == 1 && isNightmareStart == true)
        {
            nightmareTimeCounter -= minusPerSecond; //minus per second

            if(nightmareTimeCounter <= 0)
            {
                isNightmareStart = false;
                nightmareTimeCounter = 6; 
                nightmareCounter--;
            }
        }

        //For Visions
        if(isVision1 == true)
        {
            visionTimeCounter -= visionPerSecond;

            if (visionTimeCounter <= 0)
            {
                isVision1 = false;
                visionTimeCounter = 10;
                FadeNormal = false;
                isVisionSpawnCount = 0;
                isNormal = true;
            }
        }

        if (isVision2 == true)
        {
            visionTimeCounter -= visionPerSecond;

            if (visionTimeCounter <= 0)
            {
                isVision2 = false;
                visionTimeCounter = 10;
                FadeNormal = false;
                FadeVision1 = false;
                isVisionSpawnCount = 0;
                isNormal = true;
            }
        }

        if (isVision3 == true)
        {
            visionTimeCounter -= visionPerSecond;

            if (visionTimeCounter <= 0)
            {
                isVision3 = false;
                visionTimeCounter = 10;
                FadeNormal = false;
                FadeVision1 = false;
                FadeVision2 = false;
                isVisionSpawnCount = 0;
                isNormal = true;
            }
        }

        if (isPowerups == true)
        {
            powerupsTimeCounter -= powerupsPerSecond;

            if (powerupsTimeCounter <= 0)
            {
                isInvincibility = false;
                isFly = false;

                if (flyCounter == 1)
                {
                    flyAfterEffect = true;
                    descendTimeCounter -= descendPerSecond;

                    if (descendTimeCounter <= 0)
                    {
                        flyAfterEffect = false;
                        descendTimeCounter = 3;
                        --flyCounter;
                    }
                }
                else
                {
                    isPowerups = false;
                    powerupsTimeCounter = 10;
                }
            }
        }

        if(isSprint == true)
        {
            sprintTimeCounter -= sprintPerSecond;

            if(sprintTimeCounter <= 0)
            {
                isSprint = false;
                sprintTimeCounter = 15;
            }
        }

        if (isMedsBig == true)
        {
            BigMedsTimeCounter -= BigMedsPerSeconds;

            if (BigMedsTimeCounter <= 0)
            {
                isMedsBig = false;
                BigMedsTimeCounter = 1.5f;
            }
        }

        if (isMedsSmall == true)
        {
            SmallMedsTimeCounter -= SmallMedsPerSeconds;

            if (SmallMedsTimeCounter <= 0)
            {
                isMedsSmall = false;
                SmallMedsTimeCounter = 1.5f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D Ethan)
    {
        //To increment nightmare
        if (Ethan.CompareTag("Obstacle") && isInvincibility == false && flyAfterEffect == false)
       {
            nightmareCounter++; //nightmareCounter becomes 1
            isNightmareStart = true;
       }
        else if(Ethan.CompareTag("Obstacle") && nightmareCounter == 1 && nightmareTimeCounter != 0 )
        {
            nightmareCounter++;
            isNightmareStart = false;
        }

        //Vision Avolition Counter
        if(Ethan.CompareTag("Avolition"))
        {
            //This is a GetComponent for the script "BGNormal"
            isVision1 = true;
            FadeNormal = true;
            isVisionSpawnCount = 1;
            isNormal = false;
        }

        //Vision Hallucination Counter
        if(Ethan.CompareTag("Hallucination"))
        {
            isVision2 = true;
            FadeNormal = true;
            FadeVision1 = true;
            isVisionSpawnCount = 1;
            isNormal = false;
        }

        //Vision Delusion Counter
        if (Ethan.CompareTag("Delusion"))
        {
            isVision3 = true;
            FadeNormal = true;
            FadeVision1 = true;
            FadeVision2 = true;
            isVisionSpawnCount = 1;
            isNormal = false;
            nightmareCounter++;
        }

        //Powerup Invincibility Counter
        if(Ethan.CompareTag("Invincibility"))
        {
            isPowerups = true;
            isInvincibility = true;
        }

        //Powerup Fly Counter
        if (Ethan.CompareTag("Fly"))
        {
            isPowerups = true;
            isFly = true;
            flyCounter = 1;
        }

        //Powerup Sprint Counter
        if (Ethan.CompareTag("Sprint"))
        {
            isSprint = true;
        }

        //Powerup Meds Big
        if (Ethan.CompareTag("MedsBig"))
        {
            isMedsBig = true;
        }

        //Powerup Meds Big
        if (Ethan.CompareTag("MedsSmall"))
        {
            isMedsSmall = true;
        }

        //Powerup Meds Small

        //Nightmare collision
        if (Ethan.CompareTag("Nightmare"))
        {
            //Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D Ethan)
    {
        if(nightmareCounter == 1)
        {
            nightmareCounter = 1;
        }
    }
}
