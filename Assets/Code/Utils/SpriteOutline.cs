using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class SpriteOutline
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private float _duration;
    [SerializeField] private float _amount;
    private Tween _animation;

    public void Show()
    {
        PlayScaleAnimation(_amount);
    }

    public void Hide()
    {
        PlayScaleAnimation(0);
    }

    private void PlayScaleAnimation(float targetScale)
    {
        _animation?.Kill();
        _animation = _sprite.transform.DOScale(targetScale, _duration).SetLink(_sprite.gameObject);
    }
}