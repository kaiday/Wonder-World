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
        endCanvas = GameObject.Find("EndGame").gameObject;
        endCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            PlayerMovement.instance.standStill();
            FindObjectOfType<SoundManager>().playSFX("finish");
            levelCompleted = true;
            endCanvas.SetActive(true);
        }
    }

}
