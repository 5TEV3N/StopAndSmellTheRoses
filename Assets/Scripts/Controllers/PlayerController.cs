using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;           // Speed of the player
    public float playerJumpHeight;      // Jump Height 
    public bool isGrounded;             // Checks if grounded
    public float valOfVelocity;         // Checks how fast the player goes
    public float maxVelocity;           // The max speed of how fast the player goes
    public bool consumedByFog;          // if the player hits the collider of the fog, pause time, let it consume you   

    public AudioSource jumpSound;       //

    private Rigidbody2D rb;             // Access the rigidbody2D
    
    //Player Movement Section
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        valOfVelocity = rb.velocity.magnitude;
    }

    public void PlayerMove(float xAxis)
    {
        if (xAxis != 0)
        {
            if (xAxis > 0)
            {
                if (valOfVelocity <= maxVelocity) // Thanks matt f
                {
                    rb.AddForce(transform.right * playerSpeed, ForceMode2D.Impulse);
                }
            }

            if (xAxis < 0)
            {
                if(valOfVelocity <= maxVelocity)
                {
                    rb.AddForce(-transform.right * playerSpeed, ForceMode2D.Impulse);
                }
            }
        }
    }

    //Player Movement Section
    
    public void PlayerJump()
    {
        if (isGrounded == true)
        {
            rb.AddForce(transform.up * playerJumpHeight, ForceMode2D.Impulse);
            jumpSound.Play();
            isGrounded = false;
        }
    }
    
    void OnTriggerStay2D(Collider2D floor)
    {
        if (floor.gameObject.tag == "T_Floor")
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D floor)
    {
        if (floor.gameObject.tag == "T_Floor")
        {
            isGrounded = false;
        }
    }

}