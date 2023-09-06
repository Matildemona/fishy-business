using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform player;
    public TMP_Text scoretext;

    //public PlayerHealth playerHealth;


    public static int points = 0;


    void Update()
    {
        scoretext.text = player.position.z.ToString("0") + "m";

        //if (playerHealth.currentHealth <= 0)
        //{
            
        //}
    }
}
