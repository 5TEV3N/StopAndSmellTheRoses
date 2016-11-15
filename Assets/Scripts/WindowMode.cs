using UnityEngine;
using System.Collections;

public class WindowMode : MonoBehaviour
{	
	void Update ()
    {
        Screen.SetResolution(1000, 500, false);
        Screen.fullScreen = false;
    }
}
