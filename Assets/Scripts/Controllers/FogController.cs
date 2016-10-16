using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FogController : MonoBehaviour
{
    public float timeBeforeFogMoves;    // How long til the fog moves, value contains what the timer starts as
    public float fogSpeed;              // How fast the fog travels
    public Rigidbody rb;                // Container for the rigidbody

    ParticleSystem fog;

    void Start()
    {
        fog = GetComponent<ParticleSystem>();
    }

    void FixedUpdate()
    {
        timeBeforeFogMoves -= Time.deltaTime;
        if (timeBeforeFogMoves <= 0)
        {
            print("RUN!");
            var fogEmit = fog.emission;
            fogEmit.enabled = true;
            rb.AddForce(transform.right * fogSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "T_PlayerTrigger")
        {
            print("Close game");
            Application.Quit();
        }
    }
}
