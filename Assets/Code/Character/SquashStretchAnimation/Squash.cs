using DG.Tweening;
using UnityEngine;


public class Squash
{
    private readonly Transform _transform;
    private float _yScaleBeforeSquashing;
    private float _velocity;
    private const float _squashDuration = 0.45f;


    public Squash(Transform transform)
    {
        _transform = transform;
    }
    
    
    public void Play(float velocity)
    {
        _velocity = velocity;
        _yScaleBeforeSquashing = _transform.localScale.y;
        DOTween.To(SetSquash, 0, 1, _squashDuration).SetEase(Ease.Linear);
    }

    
    private void SetSquash(float normalizedValue)
    {
        float yScale = EvaluateYSquash(normalizedValue);
        float yOffset = EvaluateYOffset(yScale);
        float xScale = EvaluateXSquash(yScale);

        _transform.SetYScale(yScale);
        _transform.SetYLocalPosition(yOffset);
        _transform.SetXScale(xScale);
    }


    private float EvaluateYSquash(float normalizedValue)
    {
        float squashVelocity = EvaluateSquashVelocity();
        float normalizedYScale = EaseFunctions.OutBack(squashVelocity, normalizedValue);
        return Mathf.LerpUnclamped(_yScaleBeforeSquashing, 1, normalizedYScale);
    }

    
    private float EvaluateXSquash(float yScale)
    {
        return -0.375f * yScale + 1.375f;
    }


    private float EvaluateSquashVelocity()
    {
        return _velocity / 2f;
    }
    
    
    private float EvaluateYOffset(float yScale)
    {
        return 0.746f * yScale - 0.378f;
    }
}