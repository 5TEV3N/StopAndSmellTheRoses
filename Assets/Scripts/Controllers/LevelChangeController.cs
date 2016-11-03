using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelChangeController : MonoBehaviour
{
    MusicManager musicManager;                      // Refference to the music manager
    public float pause = 1f;                        // What time the timer starts at
    public bool lerpMusicToMute = false;            // When spacebar is hit, slowlymute
    private Scene currentScene;                     // Retrives the scene that's currently active
    private string sceneName;                       // Retrices the name of said active scene

    [Header("Title Screen")]
    public GameObject ui1;                          // ui container for the titlecreen
    public GameObject ui2;

    [Header("Pause Screen")]
    public GameObject[] subText;                    // subText container for the titlecreen

    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("T_MusicManager")!= null)
        {
            musicManager = GameObject.FindGameObjectWithTag("T_MusicManager").GetComponent<MusicManager>();
        }
    }

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (sceneName == "Pause")
        {
            GameObject subTextArray = subText[Random.Range(0, subText.Length)];
            subTextArray.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if (sceneName == "_Title")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                lerpMusicToMute = true;
                StartGame();
            }
        }

        if (sceneName == "Pause")
        {
            pause -= Time.deltaTime;
            if (pause <= 0)
            {
                print("on the next one");
                SceneManager.LoadScene(3);
            }
        }

        if (musicManager != null)
        {
            musicManager.mainBGM.volume = Mathf.Lerp(musicManager.mainBGM.volume, 0f, 0.1f);
        }

    }
    public void StartGame()
    {
        ui1.SetActive(false);
        ui2.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
