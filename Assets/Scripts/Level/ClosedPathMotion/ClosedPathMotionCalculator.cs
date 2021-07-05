using System;
using UnityEngine;


[Serializable]
public class ClosedPathMotionCalculator 
{
    [SerializeField] private ClosedPathMotionConfig _motionConfig = null;

    private float _period = 0;
    private float _time = 0;    


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