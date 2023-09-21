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
            funFact.text = "Almost 40% of the ocean surface is covered in trash.";
        }
        else if (currentCollision == "Hunger")
        {
            funFact.text = "Over 100 million marine animals die because of the lack of food or because they eat trash.";
        }
        else if (currentCollision == "Spear")
        {
            funFact.text = "Approximately 80% of the fish that we eat are being over-fished";
        }
        else if (currentCollision == "Fork")
        {
            funFact.text = "Fork is bad!";
        }
        else if (currentCollision == "Angler Fish")
        {
            funFact.text = "Each year more marine animals are found outside their habitats because of the lack of food.";
        }
        else if (currentCollision == "Eel")
        {
            funFact.text = "Coral reefs are being destroyed, causing millions of marine animal to move form their natural habitats.";
        }
        else 
        {
            currentCollision = "Hunger";
        }
    }

    /*
     
    Tin can - Almost 40% of the oceans surface is covered in trash.

Hunger - Over 100 million marine animals die because of the lack of food or because they eat trash.

Spear - Approximately 80% of the fish that we eat are being over-fished (idk if this word is correct)

Angler fish - Each year more marine animals are found outside their habitats because of the lack of food.

Eel - Coral reefs are being destroyed, causing millions of marine animal to move form their natural spots.
     */

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
