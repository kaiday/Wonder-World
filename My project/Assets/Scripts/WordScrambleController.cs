using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text wordText;
    public Text scoreText;
    public Text timeText;
    public float timeLimit = 60f;

    private string correctWord;
    private int score = 0;
    private float currentTime;

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimeText();
            if (currentTime <= 0)
            {
                EndGame();
            }
        }
    }

    public void StartGame()
    {
        score = 0;
        currentTime = timeLimit;
        UpdateScoreText();
        UpdateTimeText();
        GenerateWord();
    }

    public void CheckWord(string word)
    {
        if (word == correctWord)
        {
            score++;
            UpdateScoreText();
            GenerateWord();
        }
    }

    private void GenerateWord()
    {   
        correctWord = WordGenerator.GetRandomWord(); 
        string scrambledWord = ScrambleWord(correctWord);
        wordText.text = scrambledWord;
    }

    private string ScrambleWord(string word)
    {
        char[] letters = word.ToCharArray();
        for (int i = 0; i < letters.Length; i++)
        {
            int randomIndex = Random.Range(i, letters.Length);
            char temp = letters[i];
            letters[i] = letters[randomIndex];
            letters[randomIndex] = temp;
        }

        return new string(letters);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateTimeText()
    {
        timeText.text = "Time: " + currentTime.ToString("0");
    }

    private void EndGame()
    {
        if (score >= 10)
        {
            Debug.Log("Congratulations! You've reached a score of 10.");
            Debug.Log("Final Score: " + score.ToString());
           
        }
        else
        {
            Debug.Log("Game Over! Your score is: " + score.ToString());
           
        }
    }

}
