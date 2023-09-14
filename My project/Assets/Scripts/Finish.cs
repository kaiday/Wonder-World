using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    public GameObject endCanvas;
    private Rigidbody2D rb;
    private bool levelCompleted = false;

    private void Start()
    {
<<<<<<< Updated upstream
        finishSound = GetComponent<AudioSource>();
=======
        endCanvas = GameObject.Find("EndGame");
        rb = GetComponent<Rigidbody2D>();
>>>>>>> Stashed changes
        endCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            rb.bodyType = RigidbodyType2D.Static;
            Invoke("CompleteLevel", 0.75f);
        }
    }
    private void CompleteLevel()
    {
        endCanvas.SetActive(true);
    }
}
