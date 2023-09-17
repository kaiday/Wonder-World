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

    public void setWord(string word, string translateWord, string completeWord)
    {
        if (done)
        {
            text.text = completeWord + " = " + translateWord;
            text.color = Color.white;
        }
        else
        {
            text.text = word;
        }
    }

    public void removeWord()
    {
        Destroy(gameObject);
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

    public void translate(string word, string translateWord, string completeWord)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        done = true;
        if (done)
        {
            setWord(word, translateWord, completeWord);
        }
        Invoke("removeWord", 1.5f);
    }
    
}
