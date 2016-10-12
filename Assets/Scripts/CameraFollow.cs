using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform lookAt;                // The transform of what you want to look at
    public Vector3 offset;                  // The vector 3 of the camera and how off you want the camera
    public float smoothSpeed;               // How smooth the camera follows the lookAt transform
    public bool lerpedCamera;

    private Vector3 desiredPosition;        // Holds the value of what youre looking at and what kind of offset you have

    // desiredPosition.z to -15, when player reaches a certain collision. 

    void FixedUpdate()
    {
        desiredPosition = lookAt.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        print("Lerp Here");
        Vector3 panOut = new Vector3(desiredPosition.x,desiredPosition.y, -100f);
        transform.position = Vector3.Lerp(desiredPosition, panOut, Time.deltaTime * 1000f);
        // must check every frame!!! ^^^^^^^^^^^^^^^^^^^
    }
}