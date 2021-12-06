using UnityEngine;


public abstract class ClosedPathMotionConfig : MonoBehaviour
{
    [SerializeField] private float _inspectorSpeed = 0;
    protected float _speed => _inspectorSpeed;


    public abstract float Period { get; }

    public abstract float EvaluateMathFunction(float time);
}