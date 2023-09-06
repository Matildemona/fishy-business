using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    [SerializeField] float playerForce = 10f;
    [SerializeField] Rigidbody rb;

    public PlayerHealth playerHealth;


    // Start is called before the first frame update
    void Start()
    {
        while (playerHealth.maxHealth > 0)
        {
            rb.velocity = new Vector2(playerForce, rb.velocity.z);
        }
    }

}
