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
    [SerializeField] float fishMovesBackTime = 3f;
    [SerializeField] float fishMovesBackDistance = 20f;
    [SerializeField] float fishMovesForwardTime = 1f;
    [SerializeField] float fishMovesForwardDistance = -20f;
    

    private void Start()
    {
     Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOLocalMoveZ(fishMovesBackDistance, fishMovesBackTime));
        sequence.Append(transform.DOLocalMoveZ(fishMovesForwardDistance, fishMovesForwardTime));


        sequence.Play();
    }

    private void Update()
    {
        //transform == players transform
        //only play animation, when collider is reached.
    }

    //do update that follow the player? until a specifik point

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damageValue);
        }
    }

}
