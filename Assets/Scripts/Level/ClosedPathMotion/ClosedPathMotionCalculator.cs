using UnityEngine;
using System;


[Serializable]
public class ClosedPathMotionCalculator 
{
    [SerializeField] private ClosedPathMotionConfig _motionConfig;

    private float _period;
    private float _time;    


    public void Init()
    {
        _period = _motionConfig.Period;
    }


    public float EvaluateLerpPosition()
    {
        _time += Time.deltaTime;
        
        if (_time >= _period)
        {
            _time = 0;
        }

        return _motionConfig.EvaluateMathFunction(_time);
    }
}