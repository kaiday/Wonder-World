
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public Sound[] musicSounds, sfxSounds;

    int scene_index;

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
            s1.musicSource.volume = UIController.instance._musicSlider.value;
        }

        foreach (Sound s2 in sfxSounds)
        {
            s2.sfxSource = gameObject.AddComponent<AudioSource>();
            s2.sfxSource.clip = s2.clip;
            s2.sfxSource.volume = UIController.instance._sfxSlider.value;
            instance.sfxVolume(UIController.instance._sfxSlider.value);
            instance.sfxName = s2.name;
        }


    }

    private void Start()
    {
        scene_index = SceneManager.GetActiveScene().buildIndex;

        musicName = "Theme" + scene_index;

        playMusic(musicName);

    }

    private void Update()
    {
        int current_scene_index = SceneManager.GetActiveScene().buildIndex;

        if (current_scene_index != scene_index)
        {
            Sound s = Array.Find(musicSounds, x => x.name == musicName);
            s.musicSource.volume = 0;

            scene_index = current_scene_index;

            musicName = "Theme" + scene_index;

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
            s.musicSource.Play();
            Debug.Log("Playing" + name);

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
