using UnityEngine;
using DG.Tweening;
using LeTai.Asset.TranslucentImage;
using UnityEngine.UI;


public class WinAnimation : MonoBehaviour
{
    [SerializeField] private ScalableBlurConfig _blurConfig;
    [SerializeField] private WinEffects _effects;
    [SerializeField] private Image _levelScore;
    [SerializeField] private TranslucentImage _translucentImage;

    private readonly float _animationDuration = 2f;
    private readonly float _startWaitTime = 0.5f;
    private readonly float _targetBlur = 15f;
    private readonly Vector2 _targetPosition = Vector2.zero;


    public void Play()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(_startWaitTime);
        sequence.Append(_levelScore.transform.DOLocalMove(_targetPosition, _animationDuration).SetEase(Ease.OutBack));
        sequence.Join(DOTween.To(x => _blurConfig.Strength = x, 0 , _targetBlur , _animationDuration));
        sequence.Join(_translucentImage.DOFade(1, _animationDuration));

        sequence.onComplete = ()=>
        {
            StartCoroutine(_effects.ActivateEffects());
        };
    }
}