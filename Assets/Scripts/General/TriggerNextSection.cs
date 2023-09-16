using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNextSection : MonoBehaviour
{
    public GenerateLevel generateLevel;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player" && generateLevel.creatingSection == false)
        {
            generateLevel.creatingSection = true;
            generateLevel.GenerateSection();
        }
    }
}
