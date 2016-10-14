using UnityEngine;
using System.Collections;

public class RoseController : MonoBehaviour
{
    public bool musicStart;         // Turns the music on ONCE after it's true
    private AudioSource BGM;        // Container for the AudioSource
    
    void Start()
    {
        BGM = GetComponent<AudioSource>();
        musicStart = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "T_PlayerTrigger")
        {
            if (musicStart == false)
            {
                print("play");
                BGM.Play();
                //lerp music
                BGM.volume = Mathf.Lerp(0f, 1f, Time.deltaTime);
                musicStart = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "T_PlayerTrigger")
        {
            print("stop");
            //lerp music to mute
            BGM.Stop();
        }
    }
}
