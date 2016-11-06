using UnityEngine;
using System.Collections;

public class NervousManager : MonoBehaviour
{
    CameraShake2D cameraShake2D;                     // Refference to the cameraShake2D script

    public GameObject fogObject;                     // Container for the fog
    public float fogDifferenceDistance;              // Value of player - fog
    public float distanceOfWhenToPanic;              // Self explanatory
    [Header("----")]
    public float shakeDuration;                      // Duration of the camera shake
    public float shakeAmplitude;                     // Amplitude of the shake ("How hard it shakes")
    public float shakeDecay;                         // Decay of the shake gradually

    private Vector3 playerPosition;                  // Position of player
    private Vector3 fogPosition;                     // Position of fog
    //private GameObject camMotionBlur;                // Refference to the motionblur script
    
    void Awake()
    {
        //camMotionBlur = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MotionBlur>();
        cameraShake2D = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake2D>();
    }

    void Update()
    {
        fogPosition = fogObject.transform.position;
        playerPosition = gameObject.transform.position;

        fogDifferenceDistance = Vector3.Distance(fogPosition, playerPosition);
        
        if (fogDifferenceDistance <= distanceOfWhenToPanic)
        {
            print("Blurry and Camera shake!!");
        }
        if (fogDifferenceDistance >= distanceOfWhenToPanic)
        {
            print("Clearing Vision");
        }
    }

}
