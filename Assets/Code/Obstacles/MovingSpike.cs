using System;
using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class MovingSpike : MonoBehaviour
{
    [SerializeField] private float _coolDown = 2f;
    [SerializeField] private float _startWaitTime;
    private const string _animationName = "Idle";
    private Animator _animator;


    private void Start()
    {
        _animator = GetComponent<Animator>();

        StartCoroutine(AnimateSpike());
    }


    private IEnumerator AnimateSpike()
    {
        yield return new WaitForSeconds(_startWaitTime);

        while (true)
        {
            _animator.Play(_animationName);
            
            yield return new WaitForSeconds(_coolDown);
        }
    }
}