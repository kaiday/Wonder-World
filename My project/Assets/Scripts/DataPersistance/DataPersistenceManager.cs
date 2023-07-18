using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")] 
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;
    
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    
    public static DataPersistenceManager instance { get; private set; }
    

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one DPM!");
        }
        
        instance = this;
    }

    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        // ToDo - Load Data using the data handler
        this.gameData = dataHandler.load();
        
        // if there is no loaded data, initialize a new game
        if (this.gameData == null)
        {
            Debug.Log("No data found. Creating one");
            NewGame();
        }
        //ToDo - Push data to other scripts
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.Log("Apple Collected = " + gameData.appleCollected);
        Debug.Log("Secret collected ? " + gameData.secretCollected);
    }

    public void SaveGame()
    {
        // ToDo - pass the data to other scripts that need it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }
        
        Debug.Log("Saved apples = " + gameData.appleCollected);
        // ToDo - save the data to file using data Handler
        dataHandler.save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects =
            FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
