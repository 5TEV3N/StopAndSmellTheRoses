using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    //Store Section here. When game is launched, place prefab section into the dessignated section

    MusicManager musicManager;                      // Refference to the music manager

    [Header ("Spawns")]

    public Transform[] section1Prefab;
    public Transform[] section2Prefab;
    public Transform[] section3Prefab;

    [Header("Locations")]

    public Transform section1Location;
    public Transform section2Location;
    public Transform section3Location;

    void Awake()
    {
        musicManager = GameObject.FindGameObjectWithTag("T_MusicManager").GetComponent<MusicManager>();
    }

    void Start()
    {
        Transform section1SpawnArray = section1Prefab[Random.Range(0, section1Prefab.Length)];
        Transform section1Spawn = Instantiate(section1SpawnArray);
        section1Spawn.SetParent(section1Location);

        Transform section2SpawnArray = section2Prefab[Random.Range(0, section2Prefab.Length)];
        Transform section2Spawn = Instantiate(section2SpawnArray);
        section2Spawn.SetParent(section2Location);

        Transform section3SpawnArray = section3Prefab[Random.Range(0, section3Prefab.Length)];
        Transform section3Spawn = Instantiate(section3SpawnArray);
        section3Spawn.SetParent(section3Location);
    }

    void Update()
    {
        if (musicManager != null)
        {
            musicManager.mainBGM.volume = Mathf.Lerp(musicManager.mainBGM.volume, musicManager.mainBGMVolume, Time.deltaTime);
        }
    }
}
