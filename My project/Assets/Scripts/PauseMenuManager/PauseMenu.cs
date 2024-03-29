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
        instance = this;
        Cursor.lockState = CursorLockMode.None;
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
                Cursor.lockState = CursorLockMode.None;
                Continue();
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Pause();
            }
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
        PausePanel = GameObject.Find("SettingUI");
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
