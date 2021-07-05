using UnityEngine;


public class UniformMotionConfig : ClosedPathMotionConfig
{
    public override float Period =>  2 / _speed;


    public override float EvaluateMathFunction(float time)
    {
        return -Mathf.Abs(_speed * time - 1) + 1;
    }
}