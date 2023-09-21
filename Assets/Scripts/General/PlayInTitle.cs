using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInTitle : MonoBehaviour
{

    void Start()
    {
        AudioManager.Instance.PlayMusic(AudioManager.Instance.tLMusic);
    }
}
