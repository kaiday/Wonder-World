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
    public Canvas audioSelect;
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

    public void audSelect()
    {
        start.enabled = false;
        charr.SetActive(false);
        audioSelect.transform.DOMoveY(0f, 1.5f, false);
    }

    public void goBack()
    {
        StartCoroutine(goback());
    }
    
    public void audioBack()
    {
        StartCoroutine(audioback());
    }

    IEnumerator goback()
    {
        levelSelect.transform.DOMoveY(11f, 1.5f, false);
        yield return new WaitForSeconds(1f);
        start.enabled = true;
        charr.SetActive(true);
    }
    
    IEnumerator audioback()
    {
        audioSelect.transform.DOMoveY(11f, 1.5f, false);
        yield return new WaitForSeconds(1f);
        start.enabled = true;
        charr.SetActive(true);
    }
}   
