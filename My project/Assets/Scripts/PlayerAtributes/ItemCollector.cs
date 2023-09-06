using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int apples = 0;
    public bool secretCollected;

    [SerializeField] private Text applesText;
    [SerializeField] private Text secretText;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            FindObjectOfType<SoundManager>().playSFX("collect");
            Destroy(collision.gameObject);
            apples += 1;
            applesText.text = "Apples: " + apples;
        }

        if (collision.gameObject.CompareTag("Secret"))
        {
            Destroy(collision.gameObject);
            secretCollected = true;
            FindObjectOfType<SoundManager>().playSFX("secret");
            secretText.text = "Secret has been found!";
        }
    }
}
