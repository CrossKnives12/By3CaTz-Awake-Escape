using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGVis1 : MonoBehaviour {

    SpriteRenderer rend;

    public GameObject player;
    private PlayerCollisions pc;

    // Use this for initialization
    void Start ()
    {
        pc = player.GetComponent<PlayerCollisions>();
        rend = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (pc.FadeVision1 == true)
        {
            Color c = rend.material.color;
            c.a -= 0.01f;
            rend.material.color = c;
            if (c.a == 0f)
            {
                c.a = 0f;
            }
        }

        //Fade In
        if (pc.FadeVision1 == false) //vision is in default false
        {
            Color c = rend.material.color;
            c.a += 0.05f;
            rend.material.color = c;

            if (pc.FadeVision1 == false && c.a == 0f) //vision is false and the color is 0
            {
                c.a += 0.05f;
                rend.material.color = c;
                if (c.a == 1f)
                {
                    c.a = 1f;
                }
            }
            else
            {
                c.a = 1f;
                rend.material.color = c;
            }
        }
    }
}
