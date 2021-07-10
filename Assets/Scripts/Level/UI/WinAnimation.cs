using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class WinAnimation : MonoBehaviour
{
    [SerializeField] private Button[] _buttons = null;

    private readonly float _duration = 2f;
    private readonly float _waitTime = 0.5f;
    private readonly Vector2 _targetPosition = Vector2.zero;


    private void OnEnable()
    {
        var sequence = DOTween.Sequence();

        sequence.AppendInterval(_waitTime);
        sequence.Append(transform.DOLocalMove(_targetPosition, _duration).SetEase(Ease.OutBack));
        sequence.onComplete = () =>
        {
            foreach(Button button in _buttons)
            {
                button.interactable = true;
            }
        };
    }
}
