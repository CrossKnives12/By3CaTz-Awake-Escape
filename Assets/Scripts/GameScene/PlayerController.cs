using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;

    //private float jumpTimeCounter;
    //public float jumpTime;
    //private bool isJumping;

    private int extraJumps;
    public int extraJumpsValue;

    public int speedFly;

    PlayerCollisions pc;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PlayerCollisions>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (pc.isFly == false)
        {
            isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround); //is true if collided with ground

            if (isGrounded == true)
            {
                extraJumps = extraJumpsValue;
            }

            if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
            {

                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
            }

            rb.gravityScale = 5;
        }

        //Fly Powerup Effect
        if(pc.isFly == true)
        {
            FlyMovement();
            rb.gravityScale = 0;
        }
    }

    void FlyMovement()
    {
        float yValue = Input.GetAxis("Vertical") * Time.deltaTime * speedFly;
        transform.position += new Vector3(0, yValue, 0);
    }


}
