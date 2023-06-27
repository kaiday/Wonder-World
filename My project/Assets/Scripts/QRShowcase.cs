using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class QRShowcase : MonoBehaviour
{
    private bool entered;
    
    public SpriteRenderer imageRender;
    public SpriteRenderer bgRender;
    public TMP_Text text;

    private void OnTriggerEnter2D(Collider2D other)
    {
        entered = true;
        Debug.Log("True");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        entered = false;
        Debug.Log("False");
    }

    private void Start()
    {
        imageRender.color = new Color(1, 1, 1, 0);
        bgRender.color = new Color(1, 1, 1, 0);
        text.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (entered)
        {
            imageRender.DOFade(1f, 1.5f);
            bgRender.DOFade(1f, 1.5f);
            text.DOFade(1f, 1.5f);
        }
        else
        {
            imageRender.DOFade(0f, 1f);
            bgRender.DOFade(0f, 1f);
            text.DOFade(0f, 1f);
        }
    }
}
