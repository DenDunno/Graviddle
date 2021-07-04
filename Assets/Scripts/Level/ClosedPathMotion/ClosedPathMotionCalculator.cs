using System;
using UnityEngine;


[Serializable]
public class ClosedPathMotionCalculator 
{
    [SerializeField] private ClosedPathMotionConfig _motionConfig = null;
    [SerializeField] private float _speed = 0;

    private float _period = 0;
    private float _time = 0;
    private Func<float, float> _moveFunction = null;


    public void Init()
    {
        _moveFunction = _motionConfig.MoveFunction;
        _period = _motionConfig.PeriodFunction(_speed);
    }


    public float EvaluateLerpPosition()
    {
        _time += Time.deltaTime;
        
        if (_time >= _period)
        {
            _time = 0;
        }

        return _moveFunction(_speed * _time);        
    }
}