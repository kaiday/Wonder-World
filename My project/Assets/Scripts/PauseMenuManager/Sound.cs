using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound 
{
    public string name;

    [HideInInspector]
    [Range(0f,0.5f)]
    public float volume;

    public AudioClip clip;

    public bool loop;

    [HideInInspector]
    public AudioSource musicSource, sfxSource;
}
