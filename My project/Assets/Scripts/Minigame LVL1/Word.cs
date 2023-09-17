using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    public string missingLetter;
    public string translateWord;
    public string completeWord;
    
    private wordDisplay display;

    public Word(string _word, wordDisplay _display, string _translateWord, string _missingWord, string _missingLetter)
    {
        word = _missingWord;

        translateWord = _translateWord;
        completeWord = _word;

        missingLetter = _missingLetter;
        display = _display;
        display.setWord(word, translateWord, completeWord);
        
    }
    
    public void WordTyped()
    {
        display.translate(word, translateWord, completeWord);
    }
}
