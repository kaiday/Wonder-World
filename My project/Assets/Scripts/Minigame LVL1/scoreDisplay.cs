using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDisplay : MonoBehaviour
{
    [SerializeField] private Text score;
    [SerializeField] private Text wordTyped;
    [SerializeField] private Text Lives;
    
    public wordScore reference;

    // Update is called once per frame
    void Update()
    {
        score.text = "Score:" + reference.Score;
        wordTyped.text = "Word Typed:" + reference.Count;
        Lives.text = "Lives: " + reference.Lives;
    }
}
