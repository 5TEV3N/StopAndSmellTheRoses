using UnityEngine;
using System.Collections;

public class RoseController : MonoBehaviour
{
    public bool roseMusicStart;         // Turns the music on ONCE after it's true
    public AudioSource RoseBGM;     // Container for the AudioSource

    MusicManager musicManager;      // Refference to the music manager

    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("T_MusicManager") != null)
        {
            musicManager = GameObject.FindGameObjectWithTag("T_MusicManager").GetComponent<MusicManager>();
        }
    }

    void Start()
    {
        RoseBGM = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "T_PlayerTrigger")
        {
            //print ("music lerp to 1f");
            roseMusicStart = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "T_PlayerTrigger")
        {
            //print("music lerp to 0f");
            roseMusicStart = false;
        }
    }
}
