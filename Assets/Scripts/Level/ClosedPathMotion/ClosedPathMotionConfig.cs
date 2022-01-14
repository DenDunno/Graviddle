using UnityEngine;


public abstract class ClosedPathMotionConfig : MonoBehaviour
{
    [SerializeField] private float _inspectorSpeed;
    protected float _speed => _inspectorSpeed;


    public abstract float Period { get; }

    public abstract float EvaluateMathFunction(float time);
}