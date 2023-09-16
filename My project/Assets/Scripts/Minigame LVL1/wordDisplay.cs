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
    
    public bool done = false;

    public float fallSpeed = 1.5f;
    public float translateSpeed = 1f;

    private void Start()
    {
        score = GameObject.Find("WordManager").GetComponent<wordScore>();
        manager = GameObject.Find("WordManager").GetComponent<WordManager>();
    }

    public void setWord(string word, string translateWord)
    {
        if (done)
        {
            text.text = word + " = " + translateWord;
            text.color = Color.white;
        }
        else
        {
            text.text = word;
        }
    }

    public void removeLetter()
    {
        text.text = text.text.Remove(0,1);
        text.color = Color.red;
    }

    public void removeWord()
    {
        Destroy(gameObject);
        manager.removeActiveWord();
    }

    private void Update()
    {
        if (done)
        {
            transform.Translate(0f, translateSpeed * Time.deltaTime, 0f);  
        }
        else
        {
            transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
        }
        
        
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

    public void translate(string word, string translateWord)
    {
        manager.removeActiveWord();
        GetComponent<BoxCollider2D>().enabled = false;
        done = true;
        if (done)
        {
            setWord(word, translateWord);
        }
        Invoke("destroyWord", 1.5f);
    }

    private void destroyWord()
    {
        Destroy(gameObject);
    }
}
