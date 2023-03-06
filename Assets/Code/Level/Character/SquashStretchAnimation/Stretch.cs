using UnityEngine;

public class Stretch
{
    private readonly Transform _transform;

    public Stretch(Transform transform)
    {
        _transform = transform;
    }

    public void SetStretch(float velocity)
    {
        float yScale = EvaluateYStretch(velocity);
        float xScale = EvaluateXStretch(velocity);
        
        _transform.SetYScale(yScale);
        _transform.SetXScale(xScale);
    }

    private float EvaluateYStretch(float velocity)
    {
        return 0.02f * velocity + 1;
    }
    
    private float EvaluateXStretch(float velocity)
    {
        return -0.006f * velocity + 1;
    }
}