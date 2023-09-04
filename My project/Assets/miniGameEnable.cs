using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniGameEnable : MonoBehaviour
{
    public GameObject miniGame;
    // Start is called before the first frame update
    void Awake()
    {
        miniGame.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
