using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class WinAnimation : MonoBehaviour
{
    private readonly float _animationDuration = 2f;
    private readonly float _startWaitTime = 0.5f;
    private readonly float _targetFadingAlpha = 0.7f;
    private readonly Vector2 _targetPosition = Vector2.zero;
    
    [SerializeField] private WinEffects _effects = null;
    [SerializeField] private List<Button> _buttons = null;
    [SerializeField] private Image _levelScore = null;
    private Image _winPanel = null;


    private void Start()
    {
        _winPanel = GetComponent<Image>();
    }


    public void ShowWinPanel()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(_startWaitTime);
        sequence.Append(_levelScore.transform.DOLocalMove(_targetPosition, _animationDuration).SetEase(Ease.OutBack));
        sequence.Join(_winPanel.DOFade(_targetFadingAlpha, _animationDuration));

        sequence.onComplete = ()=>
        {
            StartCoroutine(ActivateEffects());
        };
    }


    private IEnumerator ActivateEffects()
    {
        yield return StartCoroutine(_effects.ActivateEffects());

        _buttons.ForEach(button => button.interactable = true);
    }
}
