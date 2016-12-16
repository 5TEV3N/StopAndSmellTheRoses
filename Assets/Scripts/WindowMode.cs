using UnityEngine;
using System.Collections;

public class WindowMode : MonoBehaviour
{	
	void Update ()
    {
        Screen.SetResolution(1120, 400, false);
        Screen.fullScreen = false;
    }
}
