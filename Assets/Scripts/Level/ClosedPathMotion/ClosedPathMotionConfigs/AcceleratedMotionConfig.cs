using UnityEngine;


public class AcceleratedMotionConfig : ClosedPathMotionConfig
{     
    public override float Period => 2 * Mathf.PI / _speed;


    public override float EvaluateMathFunction(float time)
    {
        return (1 - Mathf.Cos(_speed * time)) / 2;
    }
}