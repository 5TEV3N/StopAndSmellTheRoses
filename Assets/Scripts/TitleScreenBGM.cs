using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScreenBGM : MonoBehaviour {

    public AudioSource BGM;                             // Container for the AudioSource
    LevelChangeController levelChangeController;        // Refference to levelChangeController

    void Awake()
    {
        levelChangeController = GameObject.FindGameObjectWithTag("T_LevelChange").GetComponent<LevelChangeController>();
    }

    void Update ()
    {
        BGM.volume = Mathf.Lerp(BGM.volume, 0.5f, 0.01f);

        if (levelChangeController.lerpMusicToMute == true)
        {
            BGM.volume = Mathf.Lerp(BGM.volume, 0f, Time.deltaTime);
            levelChangeController.ui1.SetActive(false);
            levelChangeController.ui2.SetActive(false);

            if (BGM.volume <= 0.2f)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
