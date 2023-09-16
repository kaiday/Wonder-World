using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    public string menuName;

    private bool menuOn;

    public TMP_Text count;
    public Canvas audioCanvas;
    public Canvas pauseMenu;
    public List<ItemReference> item;
    
    public AudioSource source;

    [Header("Current Item")] public int currentItem;
    public AudioClip currentAudio;
    public TMP_Text itemName;
    public TMP_Text wordSpelling;
    public TMP_Text description;
    public Image currentSprite;

    private int maxValue;
    private int minValue;
    private float delayTime = 1f;
    private float duration = 0.5f;
    
    private void Start()
    {
        menuOn = false;
        itemChange();

        maxValue = item.Count - 1;
        minValue = 0;
    }

    public void nextItem()
    {
        if (!menuOn)
        {
            Debug.Log("Next Item");
            StartCoroutine(movenextItem());
        }
    }

    public void prevItem()
    {
        if (!menuOn)
        {
            Debug.Log("Prev Item");
            StartCoroutine(moveprevItem());
        }
    }

    public void openBackMenu()
    {
        if (!menuOn)
        {
            menuOn = true;
            pauseMenu.transform.DOMoveY(0f, 1.5f, false);
        }
        
    }

    public void backMenu()
    {
        SceneManager.LoadScene(menuName);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void closeMenu()
    {
        menuOn = false;
        pauseMenu.transform.DOMoveY(10.22f, 1.5f, false);
    }

    public void playAudio()
    {
        if (!menuOn)
        {
            source.PlayOneShot(currentAudio);
        }
        
    }

    private void Update()
    {
        count.text = "Item: " + (currentItem + 1) + "/" + item.Count;
    }

    private void itemChange()
    {
        currentSprite.GetComponent<Image>().sprite = item[currentItem].itemImg;
        itemName.text = item[currentItem].name;
        wordSpelling.text = item[currentItem].spelling;
        description.text = item[currentItem].desc;
        currentAudio = item[currentItem].audio;
    }

    private void checkListOverflow()
    {
        if (currentItem < minValue)
        {
            currentItem = maxValue;
        }else if (currentItem > maxValue)
        {
            currentItem = minValue;
        }
    }
        
    IEnumerator moveprevItem()
    {
        audioCanvas.transform.DOMoveX(-16f, duration);

        currentItem--;
        checkListOverflow();
        itemChange();
        audioCanvas.transform.DOMoveX(16f, 0f);
        audioCanvas.transform.DOMoveX(0f, duration);
        yield return new WaitForSeconds(delayTime);
    }

    IEnumerator movenextItem()
    {
        audioCanvas.transform.DOMoveX(16f, duration);
        currentItem++;
        checkListOverflow();
        itemChange();
        audioCanvas.transform.DOMoveX(-16f, 0f);
        audioCanvas.transform.DOMoveX(0f, duration);
        yield return new WaitForSeconds(delayTime);
    }
}
