using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one DPM!");
        }
        
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        // ToDo - Load Data using the data handler
        
        // if there is no loaded data, initialize a new game
        if (this.gameData == null)
        {
            Debug.Log("No data found. Creating one");
            NewGame();
        }
        //ToDo - Push data to other scripts
    }

    public void SaveGame()
    {
        // ToDo - pass the data to other scripts that need it
        
        // ToDo - save the data to file using data Handler
    }
}
