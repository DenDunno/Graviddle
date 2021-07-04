using System;
using UnityEngine;


public class ClosedPathMotion : MonoBehaviour
{
    public float Lerp { get; private set; } = 0;

    [SerializeField] private bool _motionWithAcceleration = false;
    [SerializeField] private bool _isHorizontalMovement = false;
    [SerializeField] private bool _goRight = false;
    [SerializeField] private float _distance = 0;
    [SerializeField] private float _speed = 0;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;

    private float _period = 0;
    private float _time = 0;
    private Func<float, float> _moveFunction = null;


    private void Start()
    {
        Vector3 direction = _isHorizontalMovement ? transform.right : transform.up;

        _startPosition = transform.position;
        _targetPosition = _startPosition + direction * _distance * (_goRight ? 1 : -1);

        if (_motionWithAcceleration == true)
        {
            _moveFunction = (float x) => (1 - Mathf.Cos(x)) / 2;
            _period = 2 * Mathf.PI / _speed;
        }

        else
        {
            _moveFunction = (float x) => -Mathf.Abs(x - 1) + 1;
            _period = 2 / _speed;
        }
    }


    private void Update()
    {
        _time += Time.deltaTime;
        
        if (_time >= _period)
        {
            _time = 0;
        }

        Lerp = _moveFunction(_speed * _time);

        transform.position = Vector3.Lerp(_startPosition, _targetPosition, Lerp);
    }
}
