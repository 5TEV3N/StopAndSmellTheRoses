using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Goal : MonoBehaviour
{
    public AudioSource victorySound;
    public float pingPongPosition;
    public float yPosition;
    public float timer2NextScene = 1f;

    private bool changeTime = false;
    private Renderer spriteRenderer;

    void Start()
    {
        yPosition = transform.position.y;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        pingPongPosition = Mathf.PingPong(Time.time, 2);
        transform.position =  Vector3.Lerp (transform.position, new Vector3 (transform.position.x, yPosition + pingPongPosition, transform.position.z),Time.deltaTime);

        if (changeTime == true)
        {
            timer2NextScene -= Time.deltaTime;
            if(timer2NextScene <= 0)
            {
                SceneManager.LoadScene(2);
            }
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        changeTime = true;
        other.gameObject.SetActive(false);
        spriteRenderer.enabled = false;
        victorySound.Play();
    }
}
