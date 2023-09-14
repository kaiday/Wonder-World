using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class wordSpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordCanvas;

    public GameObject prefabRef;
    public wordScore score;

    public wordDisplay SpawnWord()
    {

        Vector3 randomPos = new Vector3(Random.Range(2.5f,4.5f), -30f);
        
        GameObject wordObj = Instantiate(wordPrefab, randomPos, Quaternion.identity, wordCanvas);
        wordDisplay wordDisplay = wordObj.GetComponent<wordDisplay>();

        return wordDisplay;
    }

    private void Update()
    {
        if (score.gameEnded == true)
        {
            wordPrefab = null;
        }
        else
        {
            wordPrefab = prefabRef;
        }
    }
}
