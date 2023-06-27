using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNumber : MonoBehaviour
{
    [SerializeField] private int buttonNum;
    [SerializeField] private ButtonManager manager;

    public void click()
    {
        manager.buttonNum = buttonNum;
    }

}
