using UnityEngine;
using System;


public class MovementWithAcceleration : MonoBehaviour
{
    [SerializeField] private ClosedPathMotionConfig _motionConfig = null;

    private float _period;
    private float _time;
    private float _lerp;


    private void Start()
    {
        _motionConfig.Init(transform);
        _period = (float)(2 * Math.PI / _motionConfig.Speed);
    }


    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _period)
        {
            _time = 0;
        }

        _lerp = (float)(1 - Math.Cos(_motionConfig.Speed * _time)) / 2;

        transform.position = Vector3.Lerp(_motionConfig.StartPosition, _motionConfig.TargetPosition, _lerp);
    }
}