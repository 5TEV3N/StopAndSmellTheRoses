using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    PlayerController playerController;
    private float xAxis = 0; // 1 right -1Left

    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void FixedUpdate ()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        if (xAxis != 0)
        {
            playerController.PlayerMove(xAxis);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Jump goes here
        }
    }
}
