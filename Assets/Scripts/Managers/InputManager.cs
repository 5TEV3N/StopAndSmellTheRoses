using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    PlayerController playerController;          // Refference to playerController

    public SpriteRenderer steKun;               // Refference to SpriteRender
    public Animator steKunAnimator;             // Animator for Ste-Kun refference

    private float xAxis = 0;                    // 1 = right -1 = Left
    

    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("T_Player").GetComponent<PlayerController>();
    }

    void FixedUpdate ()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        if (xAxis != 0)
        {
            playerController.PlayerMove(xAxis);
            steKunAnimator.SetBool("isRunning", true);

            if (xAxis < 0)
            {
                steKun.flipX = true;
            }

            if (xAxis > 0)
            {
                steKun.flipX = false;
            }
        }

        if (xAxis == 0)
        {
            steKunAnimator.SetBool("isRunning", false);
        }

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            playerController.PlayerJump();
        }
    }
}
