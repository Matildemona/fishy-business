using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public static string currentCollision; 

    private void OnTriggerEnter(Collider collision)
    {
        currentCollision = collision.tag;
        Debug.Log("The current collision is " + currentCollision);
        StartCoroutine(ResetCollision());
    }
    IEnumerator ResetCollision()
    {
        yield return new WaitForSeconds(1f);
        currentCollision = "Hunger";
        Debug.Log("The current collision is " + currentCollision);
    }
}
