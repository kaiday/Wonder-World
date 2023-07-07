using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void RestartLevel()
    {
        SceneManagement.Restart();
    }

    public void NextLevel()
    {
        SceneManagement.NextLevel();
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
