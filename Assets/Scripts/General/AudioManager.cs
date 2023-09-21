using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")] 
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip[] eatSFX;
    public AudioClip tinCanSFX, spearSFX, anglerFishSFX, eelSFX, clickSFX, readysetSFX, goSFX;
    public AudioClip bGMusic, tLMusic;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
        else { return; }
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
