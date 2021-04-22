using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {

    public float Xspeed;
    public float speed;
    public float ObstaclePos;

    public GameObject player;
    PlayerCollisions pc;

	// Use this for initialization
	void Start ()
    {
        pc = player.GetComponent<PlayerCollisions>();
        transform.position += new Vector3(0, ObstaclePos, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.isSprint == true)
        {
            transform.Translate(Vector2.left * Xspeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
