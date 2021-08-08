﻿using UnityEngine;


public class MotionWithDelayConfig : ClosedPathMotionConfig
{
    public override float Period => (1 + _speed * _waitTime) / _speed * 2;

    [SerializeField] private float _waitTime = 2f;
    private float _leftLimit;
    private float _mathFunctionOffset; // y = ax + b: a = speed , x = time , b = mathFunctionOffset


    private void Start()
    {
        _leftLimit = (1 + _speed * _waitTime) / _speed;
        float x = _leftLimit + _waitTime;

        _mathFunctionOffset = 1 + _speed * x;
    }


    public override float EvaluateMathFunction(float time)
    {
        if (time >= 0 && time <= _waitTime)
        {
            return 0;
        }

        if (time >= _waitTime && time <= _leftLimit)
        {
            return _speed * (time - _waitTime);
        }

        if (time >= _leftLimit && time <= _leftLimit + _waitTime)
        {
            return 1;
        }

        return -_speed * time + _mathFunctionOffset;
    }
}