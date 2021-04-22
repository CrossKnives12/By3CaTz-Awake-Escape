using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupMovement : MonoBehaviour {

    public float speed;
    public float ObstaclePos;

    // Use this for initialization
    void Start ()
    {
        transform.position += new Vector3(0, ObstaclePos, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D powerup)
    {
        if (powerup.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

  
}
