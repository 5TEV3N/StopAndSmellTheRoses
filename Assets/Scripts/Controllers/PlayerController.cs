using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public Rigidbody2D rb;

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
    public void PlayerJump()
    {


    }
}
