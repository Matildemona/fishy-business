using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealthCollision : MonoBehaviour
{
    public int healthValue = 20;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}
