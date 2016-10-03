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

    void OnTriggerEnter2D (Collider2D player)
    {
        if (player.gameObject.tag == "T_Player")
        {
            print("You die");
        }
        
        if (gameObject.tag == "T_Section1")
        {
            print("faster");
        }

        if (gameObject.tag == "T_Section2")
        {
            print("i said faster...");
        }

        if (gameObject.tag == "T_Section3")
        {
            print("I SAID FASTER");
        }
    }
}
