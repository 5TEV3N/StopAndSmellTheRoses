using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    PlayerController playerController;
    private float xAxis = 0; // 1 right -1Left

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
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerController.PlayerJump();
        }

        if (Input.GetKeyDown(KeyCode.R))    // TESTING SCENES. PLEASE REMOVE LATER
        {
            SceneManager.LoadScene(0);
        }
    }
}
