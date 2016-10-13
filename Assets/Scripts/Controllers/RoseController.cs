using UnityEngine;
using System.Collections;

public class RoseController : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "T_Player")
        {
            //lerp music    
        }
        else
        {
            //lerp music to mute
        }
    }
}
