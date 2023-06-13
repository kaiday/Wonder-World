using UnityEngine;
using UnityEngine.SceneManagement;

public class wordRestart : MonoBehaviour
{
    [SerializeField] public GameObject retryButton;
    [SerializeField] public GameObject continueButton;
    void Start()
    {
        retryButton.SetActive(false);
        continueButton.SetActive(false);
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
