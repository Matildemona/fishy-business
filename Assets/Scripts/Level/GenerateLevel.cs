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

    private GameObject previousSection; // Store a reference to the previous section


    public void GenerateSection()
    {
        chosenSecNum = Random.Range(0, 2);

        // Destroy the previous section if it exists
        if (previousSection != null)
        {
            //This does not work.
            DestroySection();
        }

        previousSection = Instantiate(section[chosenSecNum], new Vector3(0, 0, zPos), Quaternion.identity);
        
        zPos += 100f;
        creatingSection = false;
    }

    IEnumerator DestroySection()
    {
        yield return new WaitForSeconds(waitBeforeDestroy);
        Destroy(previousSection);
    }
}
