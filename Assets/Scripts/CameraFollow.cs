using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform lookAt;    // The transform of what you want to look at
    public float smoothSpeed;   // How smooth the camera follows the lookAt transform
    public Vector3 offset;      // The vector 3 of the camera and how off you want the camera
    
    void FixedUpdate()
    {
        Vector3 desiredPosition = lookAt.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}