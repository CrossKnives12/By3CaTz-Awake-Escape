using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject[] spawnObjects = new GameObject[11];

    public GameObject collisionVision;
    private PlayerCollisions PCollisions;

    private float spawnTime;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;

    // Use this for initialization
    void Start ()
    {
        
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (timeBtwSpawn <= 0) //time to spawn an enemy
        {
            int rand = Random.Range(0, 2); //change spawnObjects to a number when adding the other spawnables, 3/4/5, 6/7/8, 9/10/11
            Instantiate(spawnObjects[rand], transform.position, Quaternion.identity); //to instantiate where



            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime; //this speeds up the game
            }
        }

        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
