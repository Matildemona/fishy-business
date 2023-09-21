using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [SerializeField] GameObject[] section;
    public float zPos = 100f;
    public bool creatingSection = false;
    public int chosenSecNum;
    public float waitBeforeDestroy = 5f;

    private GameObject previousSection;
    [SerializeField] int timeBeforeLevelDestroy = 16;
    [SerializeField] GameObject startLevel;
    [SerializeField] Canvas youWinCanvas;
    AudioManager audioManager;

    [SerializeField] int maxAmountOfLevels = 3;

    int instantiateCount = 0;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        youWinCanvas.enabled = false;
    }

    private void Update()
    {
        if (instantiateCount >= maxAmountOfLevels)
        {
            //stop time
            Time.timeScale = 0;
            //show: you win screen with button to go to next level
            youWinCanvas.enabled = true;
            //play you win sound
            //audioManager.PlaySFX(audioManager.youWinSFX);
        }
    }

    public void GenerateSection()
    {
        chosenSecNum = Random.Range(0, 2);

        previousSection = Instantiate(section[chosenSecNum], new Vector3(0, 0, zPos), Quaternion.identity);

        instantiateCount++;

        Destroy(previousSection, timeBeforeLevelDestroy);
        
        if (startLevel != null)
        {
            Destroy(startLevel, timeBeforeLevelDestroy);
        }
        
        zPos += 100f;
        creatingSection = false;
    }
}
