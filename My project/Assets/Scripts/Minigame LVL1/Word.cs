using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    private int typeIndex;

    private wordDisplay display;

    public Word(string _word, wordDisplay _display)
    {
        word = _word;
        typeIndex = 0;

        display = _display;
        display.setWord(word);
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
            display.removeWord();
        }

        return wordTyped;
    }
}
