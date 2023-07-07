using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question
{
    public string question;
    public string correctans;
    public Question(string q, string c)
    {
        question = q;
        correctans = c;
    }
}

public class Flashcard : MonoBehaviour
{
    public RectTransform r;
    public Text cardText;

    public Question[] question = new Question[3];

    private float flipTime = 0.5f;
    private int faceSide = 0; // 0 = front, 1 = back
    private int isShrinking = -1; // -1 = get smaller, 1 = get bigger
    private bool isFlipping = false;
    private int cardNum = 0;
    private float distancePerTime;
    private float timeCount = 0;

    void Start()
    {
        question[0] = new Question("one", "1");
        question[1] = new Question("two", "2");
        question[2] = new Question("three", "3");

        distancePerTime = r.localScale.x / flipTime;
        cardNum = 0;
        cardText.text = question[cardNum].question;
    }

    void Update()
    {
        if (isFlipping)
        {
            Vector3 v = r.localScale;
            v.x += isShrinking * distancePerTime * Time.deltaTime;
            r.localScale = v;

            timeCount += Time.deltaTime;
            if ((timeCount >= flipTime) && (isShrinking < 0))
            {
                isShrinking = 1;
                timeCount = 0;
                if (faceSide == 0)
                {
                    faceSide = 1;
                    cardText.text = question[cardNum].correctans;
                }
                else
                {
                    faceSide = 1;
                    cardText.text = question[cardNum].question;
                }
            }
            else if ((timeCount >= flipTime) && (isShrinking == 1))
            {
                isFlipping = false;
            }
        }
    }

    public void NextCard()
    {
        faceSide = 0;
        cardNum++;
        if (cardNum >= question.Length)
        {
            cardNum = 0;
        }
        cardText.text = question[cardNum].question;
    }

    public void FlipCard()
    {
        timeCount = 0;
        isFlipping = true;
        isShrinking = -1;
    }
}
