using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static int randomIndex;
    private static string randomWord;

    public static int randomMissingIndex;
    public static string randomMissingWord;
    
    private static string[] wordList =
    {
        "cookie", "chocolate", "milk", "tea", "sushi",
        "peach", "apple","pineapple",
         "fish", "cheese", "chicken", "bread",
         "tomato", "strawberry",
         "pumpkin", "watermelon",
         "cherry"
        
    };

    private static string[] translateList =
    {
        "Bánh quy", "Sôcôla", "Sữa", "Trà", "Sushi", "Quả đào",
        "Quả táo", "Quả dứa", "Cá", "Phô mai", "Gà", "Bánh mì",
        "Cà chua", "Dâu tây", "Quả bí ngô", "Dưa hấu", "Quả cherry"
    };

    public static string GetRandomWord()
    {
        randomIndex = Random.Range(0, wordList.Length);
        randomWord = wordList[randomIndex];
        
        return randomWord;
    }

    public static string getTranslateWord()
    {
        int transIndex = randomIndex;
        string transWord = translateList[transIndex];
        return transWord;
    }

    public static string radomMissing()
    {
        randomMissingIndex = Random.Range(0, randomWord.Length);
        randomMissingWord = randomWord;
        randomMissingWord = randomMissingWord.Remove(randomMissingIndex,1);
        randomMissingWord = randomMissingWord.Insert(randomMissingIndex,"_");

        return randomMissingWord;
    }

    public static string missingLetter()
    {
        char missingLetter = randomWord[randomMissingIndex];

        return missingLetter.ToString();
    }
}