using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FogController : MonoBehaviour
{
    public float timeBeforeFogMoves;
    public float fogSpeed;
    public Rigidbody rb;

    void FixedUpdate()
    {
        timeBeforeFogMoves -= Time.deltaTime;
        if (timeBeforeFogMoves <= 0)
        {
            print("RUN!");
            rb.AddForce(transform.right * fogSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print("Close game");
        Application.Quit();
    }
}
