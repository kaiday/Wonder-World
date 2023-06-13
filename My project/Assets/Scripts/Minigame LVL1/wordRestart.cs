using UnityEngine;
using UnityEngine.SceneManagement;

public class wordRestart : MonoBehaviour
{
    [SerializeField] public GameObject retryButton;
    [SerializeField] public GameObject continueButton;
    [SerializeField] public GameObject skipButton;
    void Start()
    {
        retryButton.SetActive(false);
        continueButton.SetActive(false);
        skipButton.SetActive(false);
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
