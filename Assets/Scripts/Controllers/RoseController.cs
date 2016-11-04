using UnityEngine;
using System.Collections;

public class RoseController : MonoBehaviour
{
    public bool musicStart;         // Turns the music on ONCE after it's true
    private AudioSource BGM;        // Container for the AudioSource

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
        BGM = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (musicStart == true)
        {
            BGM.volume = Mathf.Lerp(BGM.volume, 1f, Time.deltaTime);
            musicManager.mainBGM.volume = Mathf.Lerp(musicManager.mainBGM.volume, -0.85f, Time.deltaTime);

        }

        if (musicStart == false)
        {
            BGM.volume = Mathf.Lerp(BGM.volume, 0f, Time.deltaTime);
            musicManager.mainBGM.volume = Mathf.Lerp(musicManager.mainBGM.volume, musicManager.mainBGMVolume, Time.deltaTime);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "T_PlayerTrigger")
        {
            //print ("music lerp to 1f");
            musicStart = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "T_PlayerTrigger")
        {
            //print("music lerp to 0f");
            musicStart = false;
        }
    }
}
