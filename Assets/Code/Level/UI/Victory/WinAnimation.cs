using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


[Serializable]
public class WinAnimation
{
    [SerializeField] private Image _image;
    [SerializeField] private WinEffects _effects;
    [SerializeField] private Image _levelScore;
    [SerializeField] private Button[] _buttons;
    
    private const float _animationDuration = 2f;
    private const float _startWaitTime = 0.5f;
    private const float _targetFade = 0.6f;
    private readonly Vector2 _targetPosition = Vector2.zero;


    public void Play()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(_startWaitTime);
        sequence.Append(_levelScore.transform.DOLocalMove(_targetPosition, _animationDuration).SetEase(Ease.OutBack));
        sequence.Join(_image.DOFade(_targetFade, _animationDuration));
        sequence.OnComplete(ActivateEffects);
    }


    private async void ActivateEffects()
    {
        _effects.Init();
        await _effects.ActivateEffects();
        _buttons.ForEach(button => button.interactable = true);
    }
}