using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject OverPanel;
    
    public Text QuestionTxt;
    public Text ScoreTxt;
    public Text QuizText;
    public Image Ranking;

    public int totalQuestion;
    public int scoreCount;
    public int quizCount;

    public Sprite Fail;
    public Sprite Bronze;
    public Sprite Silver;
    public Sprite Gold;

    private void Start()
    {
        totalQuestion = QnA.Count;
        OverPanel.SetActive(false);
        generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void GameOver()
    {
        QuizPanel.SetActive(false);
        OverPanel.SetActive(true);
        compareMedal();
        ScoreTxt.text = scoreCount + "PTS";
        QuizText.text = quizCount + "/" + totalQuestion;
    }
    
    public void correct()
    {
        scoreCount += 15;
        quizCount += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
    
    void setAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answer[i];

            if (QnA[currentQuestion].CorrentAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }
    
    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            
                    QuestionTxt.text = QnA[currentQuestion].Question;
                    setAnswer();
        }
        else
        {
            Debug.Log("Out of Question");
            GameOver();
        }
        
    }

    void compareMedal()
    {
        switch (quizCount)
        {
            case 1:  
            {
                Debug.Log("You got Bronze!");
                Ranking.GetComponent<Image>().sprite = Bronze;
                break;
            } 
            case 2:
            {
                Debug.Log("You got Silver!");
                Ranking.GetComponent<Image>().sprite = Silver;
                break;
            }
            case 3:
            {
                Debug.Log("You got Gold!");
                Ranking.GetComponent<Image>().sprite = Gold;
                break;
            }
            default:
            {
                Debug.Log("You failed!");
                Ranking.GetComponent<Image>().sprite = Fail;
                break;
            }
        }
        
    }
}
