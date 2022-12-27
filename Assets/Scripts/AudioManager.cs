using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] musicSounds;
    public Sound[] sfxSounds;
    public AudioSource musicSource;
    public AudioSource sfxSource;


    private void Awake() 
    {
        instance = this;
    }

    private void Start() 
    {
        PlayMusic("Theme");
    }

    public void PlayMusic (string name)
    {
        Sound s = Array.Find(musicSounds, x => x.songName == name);

        if (s != null)
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX (string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.songName == name);

        if (s != null)
        {
            sfxSource.clip = s.clip;
            sfxSource.Play();
        }
    }

}
