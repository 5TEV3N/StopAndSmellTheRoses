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
            print("RUN");
            gameObject.transform.Translate(fogTranslate);
        }
    }
}
