using System;
using UnityEngine;


[Serializable]
public class ClosedPathMotionConfig 
{
    public Vector3 StartPosition { get; private set; }
    public Vector3 TargetPosition { get; private set; }
    public float Distance => _distance;
    public float Speed => _speed;

    [SerializeField] private bool _isHorizontalMovement;
    [SerializeField] private bool _goRight;
    [SerializeField] private float _distance;
    [SerializeField] private float _speed;


    public void Init(Transform transform)
    {
        Vector3 direction = _isHorizontalMovement ? transform.right : transform.up;

        StartPosition = transform.position;
        TargetPosition = StartPosition + direction * _distance * (_goRight ? 1 : -1);
    }
}
