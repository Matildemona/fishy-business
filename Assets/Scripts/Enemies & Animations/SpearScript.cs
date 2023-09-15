using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpearScript : MonoBehaviour
{
    public int damageValue = 20;
    [Header("Movement Values")]
    [SerializeField] float moveUpDistance = 10f;
    [SerializeField] float moveUpDuration = 2f;
    [SerializeField] float moveDownDistance = 6.25f;
    [SerializeField] float moveDownDuration = 0.5f;
    [SerializeField] float waitDuration = 1f;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damageValue);
        }
    }

    void Start()
    {
        //if (this != null)
        
       //{
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOMoveY(moveUpDistance, moveUpDuration));
        sequence.Append(transform.DOMoveY(moveDownDistance, moveDownDuration));
        sequence.Append(transform.DOMoveY(moveDownDistance, waitDuration));

        sequence.SetLoops(-1);

        sequence.Play();
        //}
        //else { DOTween.KillAll();}
    }
}

