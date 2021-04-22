using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnObjects = new GameObject[11];

    //set startWait to 2 seconds
    public float startWait;

    private int randEnemy;
    private float spawnWait;
    public float spawnLeastWait;
    public float spawnMostWait;

    public GameObject PlayerEthan;
    private PlayerCollisions viscount;

    //default is false
    public bool stop;

    // Use this for initialization
    void Start()
    {
        viscount = PlayerEthan.GetComponent<PlayerCollisions>();
        StartCoroutine(SpawnObjects());
    }

    // Update is called once per frame
    void Update()
    {
        //for now, give a value of 3 min and 5 max 
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator SpawnObjects()
    {
        //WaitForSeconds, waits for an amount of time before executing what is below it
        yield return new WaitForSeconds(startWait);

        // if stop is true, then the while loop will stop
        while (!stop)
        {
            if(viscount.isNormal == false && viscount.isVision1 == true)
            {
                randEnemy = Random.Range(2, 5);
            }
            else if(viscount.isNormal == false && viscount.isVision2 == true)
            {
                randEnemy = Random.Range(5, 8);
            }
            else if(viscount.isNormal == false && viscount.isVision3 == true)
            {
                randEnemy = Random.Range(8, 11);
            }
            else
            {
                randEnemy = Random.Range(0, 2); // 
            }

            Instantiate(spawnObjects[randEnemy], transform.position, Quaternion.identity);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}