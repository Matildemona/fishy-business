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


    public void GenerateSection()
    {
        chosenSecNum = Random.Range(0, 2);

        previousSection = Instantiate(section[chosenSecNum], new Vector3(0, 0, zPos), Quaternion.identity);

        Destroy(previousSection, timeBeforeLevelDestroy);
        
        if (startLevel != null)
        {
            Destroy(startLevel, timeBeforeLevelDestroy);
        }
        
        zPos += 100f;
        creatingSection = false;
    }
}
