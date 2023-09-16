using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public int buttonNum;
    [SerializeField] Animator animator;
    
    public void OnPress()
    {
        Debug.Log("Pressed the button " + buttonNum);
    }

    private void Update()
    {
        switch (buttonNum)
        {
            case 1: SceneManager.LoadScene("Level 1");
                break;
            case 2: SceneManager.LoadScene("Level 2");
                break;
            case 3: SceneManager.LoadScene("Level 3");
                break;
            case 4: SceneManager.LoadScene("Level 4");
                break;

            case 9: SceneManager.LoadScene("Level secret");
                break;
            case 10: SceneManager.LoadScene("AnimalAudio");
                break;
            case 11: SceneManager.LoadScene("ItemAudio");
                break;
            case 12: SceneManager.LoadScene("FruitAudio");
                break;
            case 13: SceneManager.LoadScene("MiscAudio");
                break;
        }
    }


}
