using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList =
    {
        "cookie", "chocolate", "milk", "tea", "sushi",
        "peach", "apple","pineapple",
         "fish", "cheese", "chicken", "bread",
         "tomato", "strawberry",
         "pumpkin", "watermelon",
         "cherry"
        
    };

    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];

        return randomWord;
    }
}