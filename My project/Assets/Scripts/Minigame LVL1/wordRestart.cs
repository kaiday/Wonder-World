using UnityEngine;
using UnityEngine.SceneManagement;

public class wordRestart : MonoBehaviour
{
    [SerializeField] public GameObject retryButton;
    [SerializeField] public GameObject continueButton;
    [SerializeField] public GameObject skipButton;

    public GameObject Nmap;
    public wordScore score;
    void Start()
    {
        retryButton.SetActive(false);
        continueButton.SetActive(false);
        skipButton.SetActive(false);
    }

    public void retry()
    {
        GameObject instance = Instantiate(Resources.Load(Nmap.name, typeof(GameObject))) as GameObject;
        instance.transform.parent = this.transform.parent;
        Destroy(this);
    }

    public void skip()
    {
        score.gameEnded = true;
        retryButton.SetActive(true);
        continueButton.SetActive(true);
    }
}
