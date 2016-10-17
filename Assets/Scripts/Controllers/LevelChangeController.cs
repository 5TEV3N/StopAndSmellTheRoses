using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelChangeController : MonoBehaviour
{
    Scene currentScene;     // Retrives the scene that's currently active
    string sceneName;       // Retrices the name of said active scene
    float pause = 1f;       // What time the timer starts at

    [Header("Title Screen")]
    public GameObject ui1;
    public GameObject ui2;
    public GameObject ui3;

    [Header("Pause Screen")]
    public GameObject[] subText;

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
    void Update()
    {
        if (sceneName == "Pause")
        {
            pause -= Time.deltaTime;
            if (pause <= 0)
            {
                print("on the next one");
                SceneManager.LoadScene(1);
            }
        }

    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        ui1.SetActive(false);
        ui2.SetActive(false);
        ui3.SetActive(false);
    }
}
