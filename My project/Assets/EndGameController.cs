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
        SceneController.instance.LoadLevel(nextlvlName);
    }
    public void Flashcard()
    {
        SceneController.instance.LoadLevel(flashcardName);
    }
    public void MainMenu()
    {
        SceneController.instance.LoadLevel(menuName);
    }


}
