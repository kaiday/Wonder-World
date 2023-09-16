using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Slider _musicSlider , _sfxSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void MusicVolume()
    {
        SoundManager.instance.musicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        SoundManager.instance.sfxVolume(_sfxSlider.value);
    }
}
