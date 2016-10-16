using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;           // Speed of the player
    public float playerJumpHeight;      // Jump Height 
    public bool isGrounded;             // Checks if grounded
    public Rigidbody2D rb;              // Access the rigidbody2D
    
    //Player Movement Section

    public void PlayerMove(float xAxis)
    {
        if (xAxis != 0)
        {
            if (xAxis > 0)
            {
                rb.AddForce(transform.right * playerSpeed);
                //gameObject.transform.Translate(transform.right * 0.12f);
            }

            if (xAxis < 0)
            {
                rb.AddForce(-transform.right * playerSpeed);
                //gameObject.transform.Translate(-transform.right * 0.12f);
            }
        }
    }

    //Player Movement Section
    
    public void PlayerJump()
    {
        if (isGrounded == true)
        {
            rb.AddForce(transform.up * playerJumpHeight);
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