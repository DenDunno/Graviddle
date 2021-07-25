using UnityEngine;


public abstract class ClosedPathMotionConfig : MonoBehaviour
{
    [SerializeField] private float _speedReadOnly = 0;
    protected float _speed => _speedReadOnly;


    public abstract float Period { get; }

    public abstract float EvaluateMathFunction(float time);
}