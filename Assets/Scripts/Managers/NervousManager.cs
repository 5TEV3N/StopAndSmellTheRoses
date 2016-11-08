using UnityEngine;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class NervousManager : MonoBehaviour
{
    MotionBlur motionBlur;                           // Refference to the motionblur script
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
    
    void Awake()
    {
        motionBlur = Camera.main.GetComponent<MotionBlur>();
        cameraShake2D = Camera.main.GetComponent<CameraShake2D>();
    }

    void Update()
    {
        fogPosition = fogObject.transform.position;
        playerPosition = gameObject.transform.position;

        fogDifferenceDistance = Vector3.Distance(fogPosition, playerPosition);
        
        if (fogDifferenceDistance <= distanceOfWhenToPanic)
        {
            motionBlur.blurAmount = Mathf.Lerp(motionBlur.blurAmount, motionBlur.blurAmount = 0.92f, Time.deltaTime);
            cameraShake2D.ShakeCamera(shakeDuration, shakeAmplitude, shakeDecay);
            print("Blurry and Camera shake!!");
        }

        if (fogDifferenceDistance >= distanceOfWhenToPanic)
        {
            motionBlur.blurAmount = Mathf.Lerp(motionBlur.blurAmount, motionBlur.blurAmount = 0, Time.deltaTime);
            print("Clearing Vision");
        }
    }

}
