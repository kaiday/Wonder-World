using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    private int typeIndex;
    public string translateWord;

    private wordDisplay display;

    public Word(string _word, wordDisplay _display, string _translateWord)
    {
        word = _word;
        typeIndex = 0;

        translateWord = _translateWord;

        display = _display;
        display.setWord(word, translateWord);
        
    }

    public char getNextLetter()
    {
        return word[typeIndex];
    }

    public void TypeLetter()
    {
        typeIndex++;
        display.removeLetter();
    }

    public bool WordTyped()
    {
        bool wordTyped = (typeIndex >= word.Length);
        if (wordTyped)
        {
            display.translate(word, translateWord);
        }

        return wordTyped;
    }
}
