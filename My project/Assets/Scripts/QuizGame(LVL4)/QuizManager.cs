
using UnityEngine.Pool;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Cmap;
    public GameObject Nmap;

    public GameObject QuizPanel;
    public GameObject OverPanel;

    public Text QuestionTxt;
    public Text hintTxt;
    public Image imageHint;
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

    private bool map_Changed;
    private GameObject Canvas;
    private void Start()
    {
        totalQuestion = QnA.Count;
        Canvas = GameObject.Find("Canvas");
        OverPanel.SetActive(false);
        map_Changed = false;
        generateQuestion();
    }

    public void continueButton()
    {
        changeMapOnScene.instance.updateMapActive();
    }

    public void retry()
    {
        GameObject instantiate = Instantiate(Resources.Load("QuizMap", typeof(GameObject))) as GameObject;
        instantiate.transform.parent = Cmap.transform.parent;
        Destroy(Cmap);
        map_Changed = true;

    }

    private void Update()
    {
        if (map_Changed = true) 
        {
            Cmap = GameObject.Find("QuizManager").transform.parent.gameObject;
            map_Changed = false;
        }
    }

    public void GameOver()
    {
        QuizPanel.SetActive(false);
        OverPanel.SetActive(true);
        map_Changed = false;
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
                    hintTxt.text = "Hint: " + QnA[currentQuestion].hint;
                    imageHint.GetComponent<Image>().sprite = QnA[currentQuestion].questionImage;
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
        if (quizCount > 3 && quizCount <= 6)
        {
            Debug.Log("You got Bronze!");
            Ranking.GetComponent<Image>().sprite = Bronze;
        }else if (quizCount > 6 && quizCount <= 8)
        {
            Debug.Log("You got Silver!");
            Ranking.GetComponent<Image>().sprite = Silver;
        }else if (quizCount > 8 && quizCount <= 10)
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
