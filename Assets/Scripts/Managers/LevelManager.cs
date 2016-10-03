using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    //Store Section here. When game is launched, place prefab section into the dessignated section

    //public Transform[] SectionPrefab;      // This is for testing purposes, use the bellow method once there are more section prefabs
    //public Transform[] SectionsLocation;   // This is for testing purposes, use the bellow method once there are more section prefabs
    [Header ("Spawns")]

    public Transform[] section1Prefab;
    public Transform[] section2Prefab;
    public Transform[] section3Prefab;

    [Header("Locations")]

    public Transform section1Location;
    public Transform section2Location;
    public Transform section3Location;

    void Start()
    {
        /*
        Demo of how the spawning should work
        Transform sectionSpawnArray = SectionPrefab[Random.Range(0, SectionPrefab.Length)];
        Transform sectionSpawn = Instantiate(sectionSpawnArray);
        Transform SectionSpawnPosition = SectionsLocation[Random.Range(0, SectionsLocation.Length)];

        sectionSpawn.SetParent(SectionSpawnPosition);
        */

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
}
