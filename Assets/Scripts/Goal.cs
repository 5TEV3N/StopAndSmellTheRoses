using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Goal : MonoBehaviour
{
    public Vector3 goalPosition;
    void Update()
    {
        Vector3 pingPong = new Vector3 (transform.position.x, Mathf.PingPong(Time.time, 1), transform.position.z);
        transform.position = Vector3.Lerp(transform.position, pingPong, Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(2);
    }
}
