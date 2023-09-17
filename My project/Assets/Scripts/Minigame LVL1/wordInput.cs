using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordInput : MonoBehaviour
{
    public WordManager WordManager;
    
    // Update is called once per frame
    void Update()
    {
        foreach (char letter in Input.inputString)
        {
            Debug.Log("Type " + letter);
            WordManager.TypeLetter(letter);
        }
    }
}
