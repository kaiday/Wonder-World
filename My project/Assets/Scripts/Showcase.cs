using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using TMPro;

public class Showcase : MonoBehaviour
{
    public Light2D light;
    public SpriteRenderer imageRender;
    public TMP_Text text;

    private bool entered = false;

    // Start is called before the first frame update
    void Start()
    {
        imageRender.color = new Color(1, 1, 1, 0);
        text.color = new Color(1, 1, 1, 0);
        
        light.enabled = false;
        imageRender.enabled = false;
        text.enabled = false;
    }
    
    /*
     
     Please Leave this shit alone. I lost braincell here
     
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float time = 0;

            var lightColor = light.color;
            var imageColor = imageRender.color;
            var textColor = text.color;
            while (time < duration)
            {
                float t = time / duration;
                
                light.enabled = true;
                lightColor.a = Mathf.Lerp(0, 255, t);
                
                imageRender.enabled = true;
                imageColor.a = Mathf.Lerp(0, 255, t);
                
                text.enabled = true;
                textColor.a = Mathf.Lerp(0, 255, t);
                
                time += Time.deltaTime;
            }

            lightColor.a = 255;
            textColor.a = 255;
            imageColor.a = 255;
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            entered = true;
        }
    }

    private void Update()
    {
        if (entered)
        {
            light.enabled = true;
            imageRender.enabled = true;
            imageRender.DOFade(1f, 3f);
            text.enabled = true;
            text.DOFade(1f, 3f);
        }
    }
}
