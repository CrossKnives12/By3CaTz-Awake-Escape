using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxBG : MonoBehaviour {

    //[Range(1f, 35f)]
    public float scrollSpeed;
    public float scrollOffset;

    Vector2 startPos;

    float newPos;

    public GameObject playerEthan;
    PlayerCollisions pc;

    // Use this for initialization
    void Start ()
    {
        pc = playerEthan.GetComponent<PlayerCollisions>();
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // When Ethan picks up the Sprint Powerup
        if (pc.isSprint == true)
        {
            scrollSpeed = 35;
        }
        else
        {
            scrollSpeed = 20;
        }

        // Parallax Effect: When background reaches its end destination, it respawns from the right
        newPos = Mathf.Repeat(Time.time * - scrollSpeed, scrollOffset);

        // Background moves going to the right
        transform.position = startPos + Vector2.right * newPos;
	}
}
