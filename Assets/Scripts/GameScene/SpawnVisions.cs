﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVisions : MonoBehaviour {

    public GameObject[] spawnObjects = new GameObject[3];

    public GameObject Character;
    private PlayerCollisions controller;

    //set startWait to 2 seconds
    public float startWait;

    private int randVision;

    Vector2 whereToSpawn;
    private float spawnWhere;

    private float spawnWait;
    public float spawnLeastWait;
    public float spawnMostWait;

    public bool stop;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnObjects());
        controller = Character.GetComponent<PlayerCollisions>();
    }

    // Update is called once per frame
    void Update()
    {
        //for now, give a value of 3 min and 5 max 
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
        //spawn where (x, y)
        spawnWhere = Random.Range(-3, -8f);
        whereToSpawn = new Vector2(transform.position.x, spawnWhere);
    }

    IEnumerator SpawnObjects()
    {
        //WaitForSeconds, waits for an amount of time before executing what is below it
        yield return new WaitForSeconds(startWait);
        // if stop is true, then the while loop will stop
        while (!stop)
        {
            if(controller.isVisionSpawnCount == 0)
            {
                //randomly chooses which enemy will spawn
                randVision = Random.Range(0, 3);
                //whereToSpawn = new Vector2(transform.position.x, spawnWhere);

                Instantiate(spawnObjects[randVision], whereToSpawn, Quaternion.identity);

                yield return new WaitForSeconds(spawnWait);
            }
            else
            {
                yield return new WaitForSeconds(10); 
            }
        }
    }
}
