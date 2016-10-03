using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float rayDistance;           // How long the ray. Ray has to be touching the floor
    public float playerSpeed;           // Speed of the player
    public float playerJumpHeight;      // Jump Height 
    public bool isGrounded;             // Checks if grounded
    public Rigidbody rb;                // Access the rigidbody2D
    public LayerMask ground;            // The ground is in a different layer, place it here.

    
     
    void FixedUpdate()
    {
        Vector3 down = transform.TransformDirection(Vector3.down) * rayDistance;
        Debug.DrawRay(transform.position, down, Color.magenta);
        GroundCheck();
    }
    
    //Player Movement Section
    public void PlayerMove(float xAxis)
    {
        if (xAxis != 0)
        {
            if (xAxis > 0)
            {
                rb.AddForce(transform.right * playerSpeed);
            }

            if (xAxis < 0)
            {
                rb.AddForce(-transform.right * playerSpeed);
            }
        }
    }

    //Player Jump Section
    public void PlayerJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * playerJumpHeight);
            isGrounded = false;
        }
    }

    public void GroundCheck()
    {
         if (Physics.Raycast(transform.position, Vector3.down, rayDistance, ground))
         {
             isGrounded = true;
         }
    }
}

//Please use raycasting for playerJump instead. -  Matt F
/*
public bool isGrounded;

public void PlayerJump()
{
    if (isGrounded == true)
    {
        rb.AddForce(transform.up * playerJumpHeight);
    }
}

void OnTriggerEnter2D(Collider2D floor)
{
    if(floor.gameObject.tag == "T_Floor")
    {
        isGrounded = true;
        //print("isGrounded = " + isGrounded);
    }
}

void OnTriggerExit2D(Collider2D floor)
{
    if (floor.gameObject.tag == "T_Floor")
    {
        isGrounded = false;
        //print("isGrounded = " + isGrounded);
    }
}
*/
