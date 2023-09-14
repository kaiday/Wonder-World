
using System;
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

    private bool activate;
    private GameObject buttonObj;
    public Button continueButton;
    public Button reasignContinueButton;
    private void Start()
    {
        totalQuestion = QnA.Count;
        GameObject Canvas = GameObject.Find("Canvas");
        Debug.Log(Canvas.name);
        OverPanel = Canvas.transform.Find("WinnerScore").gameObject;
        buttonObj = OverPanel.transform.Find("continueOption").gameObject;
        continueButton = buttonObj.GetComponent<Button>();
        Debug.Log(OverPanel.name);
        OverPanel.SetActive(false);
        generateQuestion();


    }

    public void retry()
    {
        GameObject instantiate = Instantiate(Resources.Load("QuizMap", typeof(GameObject))) as GameObject;
        instantiate.transform.parent = Cmap.transform.parent;
        Destroy(Cmap);
        activate = true;

    }

    private void Update()
    {
        GameObject Canvas = GameObject.Find("Canvas");
        OverPanel = Canvas.transform.Find("WinnerScore").gameObject;

        if (OverPanel.active != activate) {
            Cmap = GameObject.Find("QuizManager").transform.parent.gameObject;
            totalQuestion = QnA.Count;
            Debug.Log(Canvas.name);
            OverPanel = Canvas.transform.Find("WinnerScore").gameObject;
            buttonObj = OverPanel.transform.Find("continueOption").gameObject;
            reasignContinueButton = buttonObj.AddComponent<Button>();
            reasignContinueButton.onClick.AddListener(() => changeMapOnScene.instance.updateMapActive());
            Debug.Log(OverPanel.name);
            OverPanel.SetActive(false);
            QuizPanel = Canvas.transform.Find("PlayArea").gameObject;
            QuizPanel.SetActive(true);
            generateQuestion();
            activate = false;
        }
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
