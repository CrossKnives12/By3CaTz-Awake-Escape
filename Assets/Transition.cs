using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {

    private bool stop;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(LoadingScenes());
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator LoadingScenes()
    {
        yield return new WaitForSeconds(5);

        while(!stop)
        {
            SceneManager.LoadScene("HomeScene");
        }
    }
}
