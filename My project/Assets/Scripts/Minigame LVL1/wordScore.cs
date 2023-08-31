using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordScore : MonoBehaviour
{
    public int Score = 0;
    public int Lives = 3;
    public int Count = 0;
    public bool gameEnded = false;
    public wordRestart restart;
    public GameObject display;   
    private int finalScore;
    private int medal;

    public void addScore()
    {
        Score += 15;
        Count += 1;
    }

    public void removeScore()
    {
        Lives -= 1;
        Score -= 5;
    }

    private void medalScore()
    {
        if (finalScore > 0)
        {
            medal = 1;
        }else if (medal > 1)
        {
            medal = 2;
        }else if (medal > 2)
        {
            medal = 3;
        }
        else
        {
            medal = 0;
        }

        switch (medal)
        {
            case 1: Debug.Log("Bronze Medal (1 Star)");
                break;
            case 2: Debug.Log("Silver Medal (2 Star)");
                break;
            case 3: Debug.Log("Gold Medal (3 Star)");
                break;
            default: Debug.Log("Mission failed (we get em next time)");
                break;
        }
    }

    private void Update()
    {
        if (Score >= 150)
        {
            restart.skipButton.SetActive(true);
        }
        
        if (Lives == 0)
        {
            finalScore = Score * Count;
            restart.continueButton.SetActive(true);
            restart.retryButton.SetActive(true);
            display.SetActive(false);
            gameEnded = true;
        }
    }
}
