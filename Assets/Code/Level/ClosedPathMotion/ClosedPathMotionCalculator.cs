using UnityEngine;
using System;


[Serializable]
public class ClosedPathMotionCalculator 
{
    [SerializeField] private ClosedPathMotionType _motionType;

    private float _period;
    private float _time;    


    public void Init()
    {
        _period = _motionType.Period;
    }


    public float EvaluateLerpPosition()
    {
        _time += Time.deltaTime;
        
        if (_time >= _period)
        {
            _time = 0;
        }

        return _motionType.EvaluateMotionFunction(_time);
    }

    
    public void Restart()
    {
        _time = 0;
    }
}