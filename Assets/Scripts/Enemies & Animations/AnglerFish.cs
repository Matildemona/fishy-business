using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnglerFish : MonoBehaviour
{
    public int damageValue = 100;
    //Følg fisken I X sekunder.
    //Blink langsomt hvid i X sekunder.
    //Blink hurtigt hvid i X sekunder.
    //Rush frem mod fisken fra X til X på X sekunder
    [Header("Angler Fish Animation Values")] 
    [SerializeField] float fishMovesBackTime = 2f;
    [SerializeField] float fishMovesBackDistance = 10f;
    [SerializeField] float fishMovesForwardTime = 1f;
    [SerializeField] float fishMovesForwardDistance = -20f;

    [Header("References to Fill")]
    public Transform playerPosition;
    float currentPosition;
    bool sequence1Complete = false;

    [SerializeField] MeshRenderer anglerFishMesh;
    [SerializeField] Material whiteMaterial;
    [SerializeField] Material originalMaterial;
    float flashTime = 0.1f;

    private void Update()
    {
        if (sequence1Complete == false)
        {
            transform.position = new Vector3(playerPosition.position.x, playerPosition.position.y, transform.position.z);

        }
        else if (sequence1Complete == true) {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        else { return; }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damageValue);
        }
    }

    public void AnglerFishAnimation()
    {
        transform.DOMove(transform.position + transform.forward * fishMovesBackDistance, fishMovesBackTime).OnComplete(() =>
        {
            sequence1Complete = true;
            transform.DOMove(transform.position + transform.forward * fishMovesForwardDistance, fishMovesForwardTime).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        });
    }

    public void StartAnglerFishBlinking()
    {
        anglerFishMesh.material = whiteMaterial;
        Invoke("SecondAnglerFishBlinking", flashTime);
    }
    public void SecondAnglerFishBlinking()
    {
        anglerFishMesh.material = originalMaterial;
        Invoke("ThirdAnglerFishBlinking", flashTime);
    }
    public void ThirdAnglerFishBlinking()
    {
        anglerFishMesh.material = whiteMaterial;
        Invoke("StopAnglerFishBlinking", flashTime);
    }
    public void StopAnglerFishBlinking()
    {
        anglerFishMesh.material = originalMaterial;
    }


}
