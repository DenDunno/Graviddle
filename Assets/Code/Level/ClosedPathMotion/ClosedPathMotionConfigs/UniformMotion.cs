using UnityEngine;


public class UniformMotion : ClosedPathMotionType
{
    public override float Period =>  2 / Speed;


    public override float EvaluateMotionFunction(float time)
    {
        return -Mathf.Abs(Speed * time - 1) + 1;
    }
}