using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FogController : MonoBehaviour
{
    public float timeBeforeFogMoves;    // How long til the fog moves, value contains what the timer starts as
    public float fogSpeed;              // How fast the fog travels
    public Rigidbody rb;                // Container for the rigidbody

    private ParticleSystem fog;         // Retrieve the fog particle system 
    private ConstantForce force;        // Retrieve the constant force component

    void Start()
    {
        fog = GetComponent<ParticleSystem>();
        force = GetComponent<ConstantForce>();
    }

    void FixedUpdate()
    {
        timeBeforeFogMoves -= Time.deltaTime;
        if (timeBeforeFogMoves <= 0)
        {
            print("RUN!");

            ParticleSystem.EmissionModule fogEmit = fog.emission;
            fogEmit.enabled = true;
            force.enabled = true;
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
