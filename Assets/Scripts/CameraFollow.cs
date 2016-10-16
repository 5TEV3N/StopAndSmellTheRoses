using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform lookAt;                // The transform of what you want to look at
    public Vector3 offset;                  // How off centered the camera is
    public Vector3 newOffset;               // The new value of the offset ( after you hit the trigger )
    public Vector3 rosesOffset;             // The offset of when the roses trigger occurs
    public float smoothSpeed;               // How smooth the camera follows the lookAt transform
    public bool lerpedCameraPanOut;         // If the camera hits a trigger, start to pan out the camera
    public bool lerpedCameraPanIn;          // If the camera hits a trigger(Roses Trigger), start to pan out the camera

    private Vector3 desiredPosition;        // Holds the value of what youre looking at and what kind of offset you have
    private Vector3 newDesiredPosition;     // Holds the new value of what youre looking at and what kind offset you have ( after you hit the trigger )
    private Vector3 rosesPosition;          // Holds the value of the camera position when you reach the rose

    void Update()
    {
        if (lerpedCameraPanOut == true)
        {
            newDesiredPosition = lookAt.transform.position + newOffset;
            transform.position = Vector3.Lerp(transform.position, newDesiredPosition, Time.deltaTime);
        }
        if (lerpedCameraPanOut == false)    // Default camera position
        {
            desiredPosition = lookAt.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }

        if (lerpedCameraPanIn == true)
        {
            rosesPosition = lookAt.transform.position + rosesOffset;
            transform.position = Vector3.Lerp(transform.position, rosesPosition, Time.deltaTime);
        }

        if (lerpedCameraPanIn == false)     
        {
            newDesiredPosition = lookAt.transform.position + newOffset;
            transform.position = Vector3.Lerp(transform.position, newDesiredPosition, Time.deltaTime);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "T_PanOut")
        {
            lerpedCameraPanOut = true;
        }

        if (other.gameObject.tag == "T_Roses")
        {
            lerpedCameraPanIn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "T_Roses")
        {
            lerpedCameraPanIn = false;
        }
    }

} 