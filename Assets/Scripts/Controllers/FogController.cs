using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Windows;

public class FogController : MonoBehaviour
{
    public float timeBeforeFogMoves;    // How long til the fog moves, value contains what the timer starts as
    public float fogSpeed;              // How fast the fog moves
    public Rigidbody rb;                // Container for the rigidbody

    private AudioSource fogSounds;      // Retrieves the AudioSource
    private ParticleSystem fog;         // Retrieve the fog particle system 

    void Start()
    {
        fog = GetComponent<ParticleSystem>();
        fogSounds = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        timeBeforeFogMoves -= Time.deltaTime;
        if (timeBeforeFogMoves <= 0)
        {
            gameObject.transform.Translate(new Vector2(1,0) * fogSpeed);
            ParticleSystem.EmissionModule fogEmit = fog.emission;
            fogEmit.enabled = true;
            fogSounds.enabled = true;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "T_PlayerTrigger")
        {
            Application.Quit();
        }
    }
}
