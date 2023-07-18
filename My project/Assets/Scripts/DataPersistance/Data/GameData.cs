using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int appleCollected;
    public bool secretCollected;

    public GameData()
    {
        this.appleCollected = 0;
        this.secretCollected = false;
    }
}
