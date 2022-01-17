using UnityEngine;


public class AcceleratedMotion : ClosedPathMotionType
{     
    public override float Period => 2 * Mathf.PI / Speed;


    public override float EvaluateMotionFunction(float time)
    {
        return (1 - Mathf.Cos(Speed * time)) / 2;
    }
}