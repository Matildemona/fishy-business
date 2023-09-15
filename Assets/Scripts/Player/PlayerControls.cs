using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header ("General Setup Settings")]
    [Tooltip("How fast the player moves.")]
    [SerializeField] float controlSpeed = 27f;
    [Tooltip("How far the player can move on the X axis")]
    [SerializeField] float xRange = 9f;
    [Tooltip("How far the player can move on the Y axis")]
    [SerializeField] float yRange = 7f;

    [Header ("Screen Position Tuning")]
    [Tooltip("How much the player rotates on the Y axis")]
    [SerializeField] float positionPitchFactor = -2f;
    [Tooltip("How much the player rotates on the X axis")]
    [SerializeField] float positionYawFactor = 2f;

    [Header ("Player Input Tuning")]
    [Tooltip("How much the player rolls when moving")]
    [SerializeField] float controlPitchFactor = -15f;
    [Tooltip("How much the player tilts when moving")]
    [SerializeField] float controlRollFactor = -20f;

    //should we do a yaw here as well? idk details for later.

    float xThrow;
    float yThrow;


    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessRotation(){
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation(){
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");
        
        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange,xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange,yRange);

        transform.localPosition = new Vector3
        (clampedXPos, clampedYPos, transform.localPosition.z);
    }

}
