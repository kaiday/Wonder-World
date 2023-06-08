using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int apples = 0;
    public bool secretCollected;

    [SerializeField] private Text applesText;
    [SerializeField] private Text secretText;

    [SerializeField] private AudioSource collectionSoundEffect;
    [SerializeField] private AudioSource secretSFX;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            apples++;
            applesText.text = "Apples: " + apples;
        }

        if (collision.gameObject.CompareTag("Secret"))
        {
            Destroy(collision.gameObject);
            secretCollected = true;
            secretSFX.Play();
            secretText.text = "Secret has been found!";
        }
    }
}
