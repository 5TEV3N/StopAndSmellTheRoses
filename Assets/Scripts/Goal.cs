using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Goal : MonoBehaviour
{
    public float pingPongPosition;
    public float yPosition;

    void Start()
    {
        yPosition = transform.position.y;
    }
    void Update()
    {
        pingPongPosition = Mathf.PingPong(Time.time, 2);
        transform.position =  Vector3.Lerp (transform.position, new Vector3 (transform.position.x, yPosition + pingPongPosition, transform.position.z),Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(2);
    }
}
