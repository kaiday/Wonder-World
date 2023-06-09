using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MiniGameLV3 : MonoBehaviour
{

    private AudioSource finishSound;


    private int count = 0;


    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Animal")
        {
            count++;
            Debug.Log(count);

            if(count == 13)
            {
                finishSound.Play();
                
                Invoke("CompleteLevel", 0.75f);
            }

        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
