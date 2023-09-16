using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    public string nextlvlName;
    public string flashcardName;
    public string menuName;

    public void nextLvl()
    {
        SceneController.instance.LoadLevel();
    }
    public void Flashcard()
    {
        SceneManager.LoadScene(flashcardName);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(menuName);
    }


}
