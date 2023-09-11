using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageCollision : MonoBehaviour
{
    public int damageValue = 20;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damageValue);
            gameObject.SetActive(false);
        }
    }
}
