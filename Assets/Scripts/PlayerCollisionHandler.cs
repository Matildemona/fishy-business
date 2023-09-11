using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerCollisionHandler : MonoBehaviour
{
    public static string currentCollision; 

    public TMP_Text funFact;

    //Make the death cause change depending on the last collision
    private void OnTriggerEnter(Collider collision)
    {
        currentCollision = collision.tag;
        Debug.Log("The current collision is " + currentCollision);
        StartCoroutine(ResetCollision());
    }

    //Which fun fact will show, depending on how you die.
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
        else 
        {
            funFact.text = "hunger is bad! (else)";
        }
    }

    //Making sure that it goes back to hunger after some time
    IEnumerator ResetCollision()
    {
        yield return new WaitForSeconds(1f);
        currentCollision = "Hunger";
        Debug.Log("The current collision is " + currentCollision);
    }
}
