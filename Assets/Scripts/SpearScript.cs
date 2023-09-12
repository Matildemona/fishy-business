using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpearScript : MonoBehaviour
{
    public int damageValue = 20;

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

        sequence.Append(transform.DOMoveY(10f, 2f));
        sequence.Append(transform.DOMoveY(6.25f, 0.5f));
        sequence.Append(transform.DOMoveY(6.25f, 1f));

        sequence.SetLoops(-1);

        sequence.Play();
        //}
        //else { DOTween.KillAll();}
    }
}

