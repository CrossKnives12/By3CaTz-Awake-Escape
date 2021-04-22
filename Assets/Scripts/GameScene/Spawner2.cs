using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour {

    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    int randEnemy; //default private

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(waitSpawner());
	}
	
	// Update is called once per frame
	void Update ()
    {
        //every second spawnWait will do Random.Range
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait); 
    }

    IEnumerator waitSpawner()
    {
        //WaitForSeconds, waits for an amount of time before executing what is below it
        yield return new WaitForSeconds (startWait); 

        while (!stop) // is stop is true, then the while loop will stop
        {
            randEnemy = Random.Range(0, 2); //chooses which enemy will spawn

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.x, spawnValues.x));

            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            //spawWait will be randomized which means WaitForSeconds will be randomized.
            yield return new WaitForSeconds (spawnWait); 
        }
    }
}
