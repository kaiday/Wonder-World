using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound 
{
    public string name;

    [Range(0f,0.5f)]
    public float volume;

    public AudioClip clip;

    public bool loop;

    public AudioSource musicSource, sfxSource;
}
