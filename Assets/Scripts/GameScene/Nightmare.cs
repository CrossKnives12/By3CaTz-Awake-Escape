using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nightmare : MonoBehaviour {

    public int timeRemaining = 10;
    //public float nightmarePos;
    //public float nightmarePos2;
    //public float nightmarePos3;

    public GameObject EthanPlayer;
    private PlayerCollisions pc;

    // Use this for initialization
    void Start()
    {
        pc = EthanPlayer.GetComponent<PlayerCollisions>();
        //StartCoroutine("LoseTime");      
    }

    // Update is called once per frame
    void Update()
    {
        //brings nightmare closer to Ethan
        if (pc.nightmareCounter == 1)
        {
            transform.position = new Vector3(-21, -9.7f, 0);
        }

        //brings nightmare to original position
        if (pc.nightmareCounter == 0)
        {
            transform.position = new Vector3(-24.72f, -9.7f, 0);
        }

        //brings nightmare to kill Ethan
        if (pc.nightmareCounter == 2)
        {
                transform.position = new Vector3(-16.47f, -9.7f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D death)
    {
        if(death.CompareTag("Player"))
        {
            SceneManager.LoadScene("StoryScene");
        }
    }

}

    /*IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            transform.Translate(11,0,0);
            timeRemaining--;
        }
    }*/


