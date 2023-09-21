using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    private void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [Header("Audio Sources")] 
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip[] eatSFX;
    public AudioClip tinCanSFX, spearSFX, anglerFishSFX, eelSFX, clickSFX, readysetSFX, goSFX;
    public AudioClip bGMusic, tLMusic;

    public void PlayMusic(AudioClip audio)
    {
        musicSource.clip = audio;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    public void PlayRandomSFX()
    {
        sfxSource.clip = eatSFX[Random.Range(0, eatSFX.Length)];
        sfxSource.PlayOneShot(sfxSource.clip);
    }
}
