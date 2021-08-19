using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScoreTutorial : MonoBehaviour
{
    [SerializeField] private Image _fadingImage = null;
    [SerializeField] private Button _finishTutorialButton = null;
    [SerializeField] private Image _finishText = null;
    [SerializeField] private GameObject[] _gameplayUIToBeActivated = null;
    [SerializeField] private SwipeHandler _swipeHandler = null;

    private readonly float _buttonTargetXPosition = -180;
    private readonly float _textTargetYPosition = -464;
    private readonly float _animationDuration = 2f;


    public void FinishTutorial()
    {
        _finishTutorialButton.transform.DOMoveX(_buttonTargetXPosition, _animationDuration).SetEase(Ease.InBack);
        _finishText.transform.DOMoveY(_textTargetYPosition, _animationDuration).SetEase(Ease.InBack);
        Tween finishTween = _fadingImage.DOFade(0, _animationDuration).SetEase(Ease.Linear);

        finishTween.onComplete += () =>
        {
            _gameplayUIToBeActivated.ForEach(ui => ui.gameObject.SetActive(true));
            _swipeHandler.enabled = true;
        };
    }
}