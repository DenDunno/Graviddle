using DG.Tweening;
using UnityEngine;

public class ScalePopup : IToggleable
{
    private readonly float _duration;
    private readonly float _startScale;
    private readonly float _targetScale;
    private readonly Transform _transform;
    private Tween _animation;

    public ScalePopup(Transform transform, float duration, float startScale, float targetScale)
    {
        _duration = duration;
        _transform = transform;
        _startScale = startScale;
        _targetScale = targetScale;
    }
    
    public void Show()
    {
        PlayScaleAnimation(_targetScale);
    }

    public void Hide()
    {
        PlayScaleAnimation(_startScale);
    }

    private void PlayScaleAnimation(float targetScale)
    {
        _animation?.Kill();
        _animation = _transform.DOScale(targetScale, _duration).SetLink(_transform.gameObject);
    }
}