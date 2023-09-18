using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerCollisionHandler : MonoBehaviour
{
    public static string currentCollision; 

    public TMP_Text funFact;

    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        currentCollision = collision.tag;
        PlayCollisionSFX();
        StartCoroutine(ResetCollision());
    }

    private void Update()
    {

        if (currentCollision == "Tin Can")
        {
            funFact.text = "Tin Can is bad!";
        }
        else if (currentCollision == "Hunger")
        {
            funFact.text = "hunger is bad!";
        }
        else if (currentCollision == "Spear")
        {
            funFact.text = "Spear is bad!";
        }
        else if (currentCollision == "Fork")
        {
            funFact.text = "Fork is bad!";
        }
        else if (currentCollision == "Angler Fish")
        {
            funFact.text = "Angler Fish is bad!";
        }
        else if (currentCollision == "Eel")
        {
            funFact.text = "Eel Fish is bad!";
        }
        else 
        {
            currentCollision = "Hunger";
        }
    }

    IEnumerator ResetCollision()
    {
        yield return new WaitForSeconds(1f);
        currentCollision = "Hunger";
    }

    void PlayCollisionSFX()
    {
        if (currentCollision == "Fish")
        {
            audioManager.PlayRandomSFX();
        }
        else if (currentCollision == "Tin Can")
        {
            audioManager.PlaySFX(audioManager.tinCanSFX);
        }
        else if (currentCollision == "Spear")
        {
            audioManager.PlaySFX(audioManager.spearSFX);
        }
        else if (currentCollision == "Angler Fish")
        {
            audioManager.PlaySFX(audioManager.anglerFishSFX);
        }
        else if (currentCollision == "Eel")
        {
            audioManager.PlaySFX(audioManager.eelSFX);
        }
        else { return; }
    }
}
