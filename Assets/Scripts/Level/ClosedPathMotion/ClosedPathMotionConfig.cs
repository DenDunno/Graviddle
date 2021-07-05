using System;
using UnityEngine;


public abstract class ClosedPathMotionConfig : MonoBehaviour
{
    public abstract float Period { get; }

    public abstract float EvaluateMathFunction(float time);

    [SerializeField] private float _speedReadOnly = 0;
    protected float _speed => _speedReadOnly;
}