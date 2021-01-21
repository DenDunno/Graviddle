using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Axe : Obstacle
{
    private Rigidbody2D _rigidbody;

    private Vector3 _startPosition;
    private Quaternion _startRotation;


    private void Start()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;

        _rigidbody = GetComponent<Rigidbody2D>();
    }


    public override void Restart()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;

        _rigidbody.angularVelocity = 0;
        _rigidbody.velocity = Vector2.zero;
    }
}


