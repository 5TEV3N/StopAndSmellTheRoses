using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float playerJumpHeight;
    public Rigidbody2D rb;
    public bool isGrounded;

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
            print("isGrounded = " + isGrounded);
        }
    }

    void OnTriggerExit2D(Collider2D floor)
    {
        if (floor.gameObject.tag == "T_Floor")
        {
            isGrounded = false;
            print("isGrounded = " + isGrounded);
        }
    }
}
