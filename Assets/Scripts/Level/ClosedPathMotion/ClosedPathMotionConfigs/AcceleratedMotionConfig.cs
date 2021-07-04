using System;
using UnityEngine;


[CreateAssetMenu(menuName ="ClosedPathMotionConfig/AcceleratedMotionConfig" , fileName = "AcceleratedMotionConfig")]
public class AcceleratedMotionConfig : ClosedPathMotionConfig
{
    public override Func<float, float> MoveFunction => (float x) => (1 - Mathf.Cos(x)) / 2;

    public override Func<float, float> PeriodFunction => (float x) => 2 * Mathf.PI / x;
}