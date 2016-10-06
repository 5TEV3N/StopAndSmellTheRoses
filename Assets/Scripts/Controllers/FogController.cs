using UnityEngine;
using System.Collections;

public class FogController : MonoBehaviour
{
    public float timeBeforeFogMoves;
    public Vector3 fogTranslate = new Vector3 (0.5f,0,0);

    void FixedUpdate()
    {
        timeBeforeFogMoves -= Time.deltaTime;
        if (timeBeforeFogMoves <= 0)
        {
            gameObject.transform.Translate(fogTranslate);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "T_Player")
        {
            print("You die");
        }
    }
}
