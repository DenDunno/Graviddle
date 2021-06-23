using System;
using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour , IRestartableObject
{
    public bool IsAlive { get; private set; } = true;

    private readonly float _rotationSpeed = 5f;

    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Quaternion _newRotation;  

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    
    private void Start()
    {
           
    }


    private void FixedUpdate()
    {
        SetState();
    }


    


    private void SetState()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.15f);

        if (colliders.Length > 1)
        {
            _animator.Play("Fall");
        }

        else
        {

        }
    }


    public void Restart()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        _rigidbody.velocity = Vector2.zero;
    }
}



