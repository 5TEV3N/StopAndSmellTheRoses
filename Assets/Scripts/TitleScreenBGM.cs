using UnityEngine;
using System.Collections;

public class TitleScreenBGM : MonoBehaviour {

    public AudioSource BGM;                             // Container for the AudioSource
    LevelChangeController levelChangeController;        // Refference to levelChangeController

    void Awake()
    {
        levelChangeController = GameObject.FindGameObjectWithTag("T_LevelChange").GetComponent<LevelChangeController>();
    }

    void Update ()
    {
        BGM.volume = Mathf.Lerp(BGM.volume, 0.5f, Time.deltaTime);

        if (levelChangeController.lerpMusicToMute == true)
        {
            BGM.volume = 0f;
        }
    }
}
