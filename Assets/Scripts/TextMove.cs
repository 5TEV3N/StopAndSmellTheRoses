using UnityEngine;
using System.Collections;

public class TextMove : MonoBehaviour
{
    public float xyzScale = 50f;

	void Update ()
    {
        transform.localScale = new Vector3(50f, 50f, 50f) * Time.deltaTime;
    }
}