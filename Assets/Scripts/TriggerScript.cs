using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerScript : MonoBehaviour
{
    public AnglerFish anglerFishScript;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            anglerFishScript.AnglerFishAnimation();
            anglerFishScript.StartAnglerFishBlinking();
            gameObject.SetActive(false);
        }
    }
}
