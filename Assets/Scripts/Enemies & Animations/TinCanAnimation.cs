using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TinCanAnimation : MonoBehaviour
{
    [SerializeField] float movingDistance = 2f;
    [SerializeField] float movingTime = 2f;
    private void Start()
    {
        // transform.DOMoveY(movingDistance, movingTime).SetLoops(-1, LoopType.Yoyo);

        transform.DOMove(transform.position+transform.up* movingDistance, movingTime).SetLoops(-1, LoopType.Yoyo);
        //transform.rotation = Random.rotation;
    }

}
