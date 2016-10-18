using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    private Scene currentScene;                     // Retrives the scene that's currently active
    private string sceneName;                       // Retrices the name of said active scene
    public float mainBGMVolume;                     // volume of mainBGM

    public AudioSource mainBGM;                     // Container for the AudioSource

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        DontDestroyOnLoad(gameObject);
    }
}
