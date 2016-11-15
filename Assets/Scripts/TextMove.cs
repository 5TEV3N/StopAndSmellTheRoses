using UnityEngine;
using System.Collections;

public class TextMove : MonoBehaviour
{
    public float xyzScale = 50f;

	void Update ()
    {
        transform.localScale = new Vector3(xyzScale, xyzScale, xyzScale) * Time.deltaTime;
    }
}