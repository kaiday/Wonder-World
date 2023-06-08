using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordSpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordCanvas;
    
    public wordDisplay SpawnWord()
    {
        Vector3 randomPos = new Vector3(Random.Range(-2.5f, 4.5f), 14f);
        
        GameObject wordObj = Instantiate(wordPrefab, randomPos, Quaternion.identity, wordCanvas);
        wordDisplay wordDisplay = wordObj.GetComponent<wordDisplay>();

        return wordDisplay;
    }
}
