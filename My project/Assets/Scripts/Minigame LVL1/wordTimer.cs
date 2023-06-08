using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordTimer : MonoBehaviour
{
    public WordManager WordManager;
    public float wordDelay = 1f;
    private float nextWordTime = 0f;

    private void Update()
    {
        if (Time.time >= nextWordTime)
        {
            WordManager.AddWord();
            nextWordTime = Time.time + wordDelay;
            wordDelay *= 1.99f;
        }
    }
}
