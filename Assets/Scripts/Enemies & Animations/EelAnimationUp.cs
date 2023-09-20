using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EelAnimationUp : MonoBehaviour
{
    [SerializeField] float movingDistance = 10f;
    [SerializeField] float movingDuration = 2f;

    void Start()
    {
        transform.DOMoveY(movingDistance, movingDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuint);
    }

    public int damageValue = 20;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damageValue);
        }
    }
}
