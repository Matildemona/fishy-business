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
    public AudioManager audioManager;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damageValue);
        }
    }

    void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOMoveY(moveUpDistance, moveUpDuration));
        sequence.Append(transform.DOMoveY(moveDownDistance, moveDownDuration));
        sequence.Append(transform.DOMoveY(moveDownDistance, waitDuration));

        sequence.SetLoops(-1);

        sequence.Play();
    }

    private void Update()
    {
        if(transform.position.y == -2.5f)
        {
            audioManager.PlaySFX(audioManager.spearSFX);
            Debug.Log("Playing Spear Sound");
        }
    }
}

