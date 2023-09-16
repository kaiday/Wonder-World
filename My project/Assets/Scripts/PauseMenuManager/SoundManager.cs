
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public Sound[] musicSounds, sfxSounds;

    string musicName;

    string sfxName;

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

        foreach (Sound s1 in musicSounds)
        {
            s1.musicSource = gameObject.AddComponent<AudioSource>();
            s1.musicSource.clip = s1.clip;
            s1.musicSource.loop = s1.loop;
            s1.musicSource.volume = 0.4f;
        }

        foreach (Sound s2 in sfxSounds)
        {
            s2.sfxSource = gameObject.AddComponent<AudioSource>();
            s2.sfxSource.clip = s2.clip;
            s2.sfxSource.volume = 0.4f;         
        }

    }

    private void Start()
    {
        instance = this;
        musicName = SceneManager.GetActiveScene().name;

        playMusic(musicName);

    }

    private void Update()
    {
        string current_music = SceneManager.GetActiveScene().name;

        if (current_music != musicName)
        {
            Sound s = Array.Find(musicSounds, x => x.name == musicName);

            if (s == null) 
            {
                Debug.Log("Sound Not Found");
                musicName = current_music;
                return;
            }

            s.musicSource.volume = 0;

            musicName = current_music;

            playMusic(musicName);

        }

    }

    public void playMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            s.musicSource.volume = UIController.instance._musicSlider.value;    
            Debug.Log(s.musicSource.volume);
            s.musicSource.Play();      
            Debug.Log("Playing" + s.name);

        }
    }

    public void playSFX (string name) 
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            s.volume = UIController.instance._sfxSlider.value;
            s.sfxSource.PlayOneShot(s.clip);
        }
    }

    public void musicVolume(float volume)
    {
        Sound s = Array.Find(musicSounds, x => x.name == musicName);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            s.musicSource.volume = volume;
        }
        
    }

    public void sfxVolume(float volume) 
    {
        foreach (Sound s in sfxSounds)
        {
            if (s == null)
            {
                Debug.Log("Sound Not Found");
            }
            else
            {
                s.sfxSource.volume = volume;
            }
        }
    }
    
}
