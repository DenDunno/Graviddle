using System;
using UnityEngine;


[Serializable]
public class ClosedPathMotionConfig 
{
    public Vector3 StartPosition { get; private set; }
    public Vector3 TargetPosition { get; private set; }
    public float Distance => _distance;
    public float Speed => _speed;

    [SerializeField] private bool _isHorizontalMovement = false;
    [SerializeField] private bool _goRight = false;
    [SerializeField] private float _distance = 0;
    [SerializeField] private float _speed = 0;


    public void Init(Transform transform)
    {
        Vector3 direction = _isHorizontalMovement ? transform.right : transform.up;

        StartPosition = transform.position;
        TargetPosition = StartPosition + direction * _distance * (_goRight ? 1 : -1);
    }
}
