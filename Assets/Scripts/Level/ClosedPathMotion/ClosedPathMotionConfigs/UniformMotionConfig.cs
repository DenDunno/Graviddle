using System;
using UnityEngine;


[CreateAssetMenu(menuName = "ClosedPathMotionConfig/UniformMotionConfig", fileName = "UniformMotionConfig")]
public class UniformMotionConfig : ClosedPathMotionConfig
{
    public override Func<float, float> MoveFunction => (float x) => -Mathf.Abs(x - 1) + 1;

    public override Func<float, float> PeriodFunction => (float x) => 2 / x;
}