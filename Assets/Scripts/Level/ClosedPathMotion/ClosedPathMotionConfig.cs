using System;
using UnityEngine;


public abstract class ClosedPathMotionConfig : ScriptableObject
{
    public abstract Func<float, float> MoveFunction { get; }
    public abstract Func<float, float> PeriodFunction { get; }
}