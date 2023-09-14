using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigMovement : MonoBehaviour
{
    [Header("Movement Speed")]
    [Tooltip("How fast the player moves")]
    [SerializeField] float moveSpeed = 5.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
