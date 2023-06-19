using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManagement : MonoBehaviour
{
    public GameObject QuizPanel;
    public GameObject OverPanel;

    public Text ScoreTxt;
    public Image Ranking;

    public int scoreCount;

    public Sprite Fail;
    public Sprite Bronze;
    public Sprite Silver;
    public Sprite Gold;

    private void Start()
    {
        OverPanel.SetActive(false);
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOver()
    {
        QuizPanel.SetActive(false);
        OverPanel.SetActive(true);
        compareMedal();
        ScoreTxt.text = scoreCount + "PTS";
    }



    void compareMedal()
    {
        if (scoreCount > 3 && scoreCount <= 6)
        {
            Debug.Log("You got Bronze!");
            Ranking.GetComponent<Image>().sprite = Bronze;
        }
        else if (scoreCount > 6 && scoreCount <= 8)
        {
            Debug.Log("You got Silver!");
            Ranking.GetComponent<Image>().sprite = Silver;
        }
        else if (scoreCount > 8 && scoreCount <= 10)
        {
            Debug.Log("You got Gold!");
            Ranking.GetComponent<Image>().sprite = Gold;
        }
        else
        {
            Debug.Log("You failed!");
            Ranking.GetComponent<Image>().sprite = Fail;
        }
    }
}
