using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FogController : MonoBehaviour
{
    public float timeBeforeFogMoves;    // How long til the fog moves, value contains what the timer starts as
    public float fogSpeed;
    public Rigidbody rb;                // Container for the rigidbody


    private ParticleSystem fog;         // Retrieve the fog particle system 

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
            gameObject.transform.Translate(new Vector2(1,0) * fogSpeed);
            ParticleSystem.EmissionModule fogEmit = fog.emission;
            fogEmit.enabled = true;

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
