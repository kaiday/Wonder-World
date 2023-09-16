using UnityEngine;
using UnityEngine.SceneManagement;

public class wordRestart : MonoBehaviour
{
    [SerializeField] public GameObject retryButton;
    [SerializeField] public GameObject continueButton;
    [SerializeField] public GameObject skipButton;

    public wordScore score;
    void Start()
    {
        retryButton.SetActive(false);
        continueButton.SetActive(false);
        skipButton.SetActive(false);
    }

    public void restart()
    {
        retryButton.SetActive(false);
        continueButton.SetActive(false);
        skipButton.SetActive(false);
        score.gameEnded = false;
        score.Lives = 3;
        score.Score = score.Count = 0;
    }

    public void skip()
    {
        score.gameEnded = true;
        changeMapOnScene.instance.updateMapActive();
    }
}
