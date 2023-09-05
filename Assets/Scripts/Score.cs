using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform player;
    public TMP_Text scoretext;

    void Update()
    {
        scoretext.text = player.position.z.ToString("0") + "m";
    }
}
