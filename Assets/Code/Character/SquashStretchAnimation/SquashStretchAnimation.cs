using DG.Tweening;
using UnityEngine;


public class SquashStretchAnimation : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private CollisionsList _characterFeet;
    private const float _squashDuration = 0.3f;
    private bool _isFalling;
    private float _yScaleBeforeSquashing;
    private float _velocity;

    
    private void Update()
    {
        if (_characterFeet.CheckCollision<Ground>() == false)
        {
            _isFalling = true;
            _velocity = _rigidbody.velocity.magnitude;
            Stretch();
        }
        else
        {
            if (_isFalling)
            {
                _isFalling = false;
                Squash();
            }
        }
    }


    private void Stretch()
    {
        transform.SetYScale(EvaluateYStretch());
        transform.SetXScale(EvaluateXStretch());
    }
    

    private void Squash()
    {
        _yScaleBeforeSquashing = transform.localScale.y;
        DOTween.To(Squash, 0, 1, _squashDuration).SetEase(Ease.Linear);
    }

    
    private void Squash(float normalizedValue)
    {
        float yScale = EvaluateYSquash(normalizedValue);
        transform.SetYScale(yScale);
        transform.SetYLocalPosition(EvaluateYOffset(yScale));
        transform.SetXScale(EvaluateXSquash(yScale));
    }


    private float EvaluateYStretch()
    {
        return 0.02f * _velocity + 1;
    }
    
    
    private float EvaluateXStretch()
    {
        return -0.006f * _velocity + 1;
    }


    private float EvaluateYOffset(float yScale)
    {
        return 0.746f * yScale - 0.378f;
    }


    private float EvaluateSquashVelocity()
    {
        return _velocity / 2f;
    }


    private float EvaluateXSquash(float yScale)
    {
        return -0.375f * yScale + 1.375f;
    }


    private float EvaluateYSquash(float normalizedValue)
    {
        float squashVelocity = EvaluateSquashVelocity();
        float normalizedYScale = EaseFunctions.OutBack(squashVelocity, normalizedValue);
        return Mathf.LerpUnclamped(_yScaleBeforeSquashing, 1, normalizedYScale);
    }
}