using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    GameObject[] pause;

	// Use this for initialization
	void Start ()
    {
        pause = GameObject.FindGameObjectsWithTag("pause");
        foreach(GameObject pauobj in pause)
        {
            pauobj.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void pauseGame()
    {
        Time.timeScale = 0;
        foreach (GameObject pauobj in pause)
        {
            pauobj.SetActive(true);
        }
    }

    public void unpauseGame()
    {
        Time.timeScale = 1;
        foreach (GameObject pausobj in pause)
        {
            pausobj.SetActive(false);
        }
    }
}
