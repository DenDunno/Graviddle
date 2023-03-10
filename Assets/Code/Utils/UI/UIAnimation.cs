using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class UIAnimation
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _duration = 2f;
    [SerializeField] private float _delay;
    private RectTransform _transform;
    private Vector3 _targetPosition;
    private Sequence _animation;

    public void Init(Vector3 targetPosition, RectTransform transform)
    {
        _targetPosition = targetPosition;
        _transform = transform;
    }

    public UniTask Play()
    {
        _animation?.Kill();
        
        _animation = DOTween.Sequence();
        _animation.AppendInterval(_delay);
        _animation.Append(_transform.DOMove(_targetPosition, _duration)
                                    .SetEase(_curve)
                                    .SetLink(_transform.gameObject));

        return _animation.ToUniTask();
    }
}