using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform lookAt;                // The transform of what you want to look at
    public Vector3 offset;                  // How off centered the camera is
    public Vector3 newOffset;               // The new value of the offset ( after you hit the trigger )
    public float smoothSpeed;               // How smooth the camera follows the lookAt transform
    public bool lerpedCameraPanOut;         // If the camera hits a trigger, start to pan out the camera

    private Vector3 desiredPosition;        // Holds the value of what youre looking at and what kind of offset you have
    private Vector3 newDesiredPosition;     // Holds the new value of what youre looking at and what kind offset you have ( after you hit the trigger )

    void FixedUpdate()
    {
        if (lerpedCameraPanOut == true)
        {
            newDesiredPosition = lookAt.transform.position + newOffset;
            transform.position = Vector3.Lerp(transform.position, newDesiredPosition, Time.deltaTime);
        }
        else
        {
            desiredPosition = lookAt.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        lerpedCameraPanOut = true;
    }
}