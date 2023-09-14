using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class wordDisplay : MonoBehaviour
{
    public Text text;
    public wordScore score;
    public WordManager manager;

    public float fallSpeed = 1.5f;

    private void Start()
    {
        score = GameObject.Find("WordManager").GetComponent<wordScore>();
        manager = GameObject.Find("WordManager").GetComponent<WordManager>();
    }

    public void setWord(string word)
    {
        text.text = word;
    }

    public void removeLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
    }

    public void removeWord()
    {
        Destroy(gameObject);
        manager.removeActiveWord();
    }

    private void Update()
    {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
        
        if (score.gameEnded == true)
        {
            removeWord();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            removeWord();
            score.removeScore();
        }
    }
}
