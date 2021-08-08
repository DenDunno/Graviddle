using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class WinAnimation : MonoBehaviour
{
    private readonly float _duration = 2f;
    private readonly float _waitTime = 0.5f;
    private readonly float _imageFading = 0.7f;
    private readonly Vector2 _targetPosition = Vector2.zero;
    
    [SerializeField] private WinEffects _effects = null;
    [SerializeField] private Image _image = null;


    private void OnEnable()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(_waitTime);
        sequence.Append(transform.DOLocalMove(_targetPosition, _duration).SetEase(Ease.OutBack));
        sequence.Join(_image.DOFade(_imageFading, _duration));

        sequence.onComplete = ()=> _effects.ActivateEffects();
    }
}