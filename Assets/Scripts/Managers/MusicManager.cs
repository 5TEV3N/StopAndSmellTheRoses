using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    RoseController roseController;                  // Refference to the RoseController script
    private Scene currentScene;                     // Retrives the scene that's currently active
    private string sceneName;                       // Retrices the name of said active scene

    public float mainBGMVolume;                     // Volume of mainBGM
    public bool roseInScene;                        // Checks if the roses are in the scene
    public AudioSource mainBGM;                     // Container for the AudioSource

    void Awake()
    {
        mainBGM.volume = mainBGMVolume;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("T_Roses") != null)
        {
            roseController = GameObject.FindGameObjectWithTag("T_Roses").GetComponent<RoseController>();
            roseInScene = true;
        }
        else
        {
            roseInScene = false;
        }

        if (GameObject.FindGameObjectWithTag("T_Fog") != null)
        {
            GameObject fog = GameObject.FindGameObjectWithTag("T_Fog");
            GameObject player = GameObject.FindGameObjectWithTag("T_Player");
            AudioSource fogNoise = GameObject.FindGameObjectWithTag("T_Fog").GetComponent<AudioSource>();
            float distanceBetweenFogAndPlayer =  player.transform.position.x - fog.transform.position.x;
            float fogNoiseVolumeOriginal = fogNoise.volume;

            if (distanceBetweenFogAndPlayer <= 10f)
            {
                fogNoise.volume = Mathf.Lerp(fogNoise.volume, 1f, Time.deltaTime);    
            }
            else
            {
                fogNoise.volume = Mathf.Lerp(fogNoise.volume, fogNoiseVolumeOriginal, Time.deltaTime);
            }
        }

        if (gameObject != null)
        {
            currentScene = SceneManager.GetActiveScene();
            sceneName = currentScene.name;

            if (sceneName == "Pause")
            {
                mainBGM.volume = Mathf.Lerp(mainBGM.volume, 0f, Time.deltaTime);
            }

            if (sceneName == "Loop" && roseInScene == false )
            {
                mainBGM.volume = Mathf.Lerp(mainBGM.volume, mainBGMVolume, Time.deltaTime);
            }

            if (sceneName == "Loop" && roseInScene == true)
            {
                if (roseController.roseMusicStart == true)
                {
                    roseController.RoseBGM.volume = Mathf.Lerp(roseController.RoseBGM.volume, 1f, Time.deltaTime);
                    mainBGM.volume = Mathf.Lerp(mainBGM.volume, 0f, Time.deltaTime);
                }

                if (roseController.roseMusicStart == false)
                {
                    roseController.RoseBGM.volume = Mathf.Lerp(roseController.RoseBGM.volume, 0f, Time.deltaTime);
                    mainBGM.volume = Mathf.Lerp(mainBGM.volume, mainBGMVolume, Time.deltaTime);
                }
            }
        }
    }

}
