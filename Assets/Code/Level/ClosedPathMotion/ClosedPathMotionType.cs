using UnityEngine;

public abstract class ClosedPathMotionType : MonoBehaviour
{
    [SerializeField] private float _inspectorSpeed;
    protected float Speed => _inspectorSpeed;

    public abstract float Period { get; }

    public abstract float EvaluateMotionFunction(float time);
}