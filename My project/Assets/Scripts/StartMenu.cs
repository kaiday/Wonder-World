using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Canvas start;
    public Canvas levelSelect;
    public GameObject charr;
    
    private void Start()
    {
        levelSelect.transform.position = new Vector2(0f, 11f);
    }

    public void lvlSelect()
    {
        start.enabled = false;
        charr.SetActive(false);
        levelSelect.transform.DOMoveY(0f, 1.5f, false);
    }

    public void learnAudio()
    {
        
    }
    
    public void goBack()
    {
        StartCoroutine(goback());
    }

    IEnumerator goback()
    {
        levelSelect.transform.DOMoveY(11f, 1.5f, false);
        yield return new WaitForSeconds(1f);
        start.enabled = true;
        charr.SetActive(true);
    }
}   
