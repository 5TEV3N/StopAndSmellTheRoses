using UnityEngine;
using System.Collections;

public class RoseController : MonoBehaviour
{
    public bool musicStart;         // Turns the music on ONCE after it's true
    private AudioSource BGM;        // Container for the AudioSource
    
    void Start()
    {
        BGM = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (musicStart == true)
        {
            BGM.volume = Mathf.Lerp(BGM.volume, 1f, Time.deltaTime);
        }

        if (musicStart == false)
        {
            BGM.volume = Mathf.Lerp(BGM.volume, 0f, Time.deltaTime);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "T_PlayerTrigger")
        {
            print ("music lerp to 1f");
            musicStart = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "T_PlayerTrigger")
        {
            print("music lerp to 0f");
            musicStart = false;
        }
    }
}
