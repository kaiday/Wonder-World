using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    public static PauseMenu instance;

    public static bool GameIsPause;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        PausePanel = GameObject.Find("SettingUI");
        PausePanel.SetActive(false);
        GameIsPause = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPause) 
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }

        else if(SceneManager.GetActiveScene().name == "End Creen")
        {
            PausePanel.SetActive(false);
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void HomeButton()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
