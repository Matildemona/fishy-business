using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")] 
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip[] eatSFX;
    public AudioClip tinCanSFX;
    public AudioClip spearSFX;
    public AudioClip anglerFishSFX;
    public AudioClip eelSFX;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    private void Start()
    {
        if (musicSource.isPlaying == false)
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
