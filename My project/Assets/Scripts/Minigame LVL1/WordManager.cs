using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class WordManager : MonoBehaviour
{
    public List<Word> words;

    public Word word;
    public wordSpawner wordSpawner;
    public wordScore wordScore;

    public void AddWord()
    {
        word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord(), WordGenerator.getTranslateWord(), WordGenerator.radomMissing(), WordGenerator.missingLetter());
        Debug.Log(word.word + " " + word.completeWord + " Missing: " + word.missingLetter);
        
        words.Add(word);
    }       

    public void TypeLetter(char letter)
    {
        foreach (Word word in words)
        {
            if (word.missingLetter.Equals(letter.ToString()))
            {
                Debug.Log("Run");
                word.WordTyped();
                wordScore.addScore();
                words.Remove(word);
            }
        }
        
    }
}
