using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject endCanvas;

    private bool levelCompleted = false;

    private void Start()
    {
        endCanvas = GameObject.Find("EndGame");
        endCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            FindObjectOfType<SoundManager>().playSFX("finish");
            levelCompleted = true;
            Invoke("CompleteLevel", 1.25f);
        }
    }

    private void CompleteLevel()
    {
        endCanvas.SetActive(true);
    }
}
