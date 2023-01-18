using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class IconAnimation : MonoBehaviour, IPointerClickHandler
{
    private const float _duration = 0.13f;
    private const float _coolDown = 1.2f;
    private const int _rotations = 2;
    private readonly Vector3 _rotationVector = new(0, 0, -25);
    private Sequence _sequence;

    private void Start()
    {
        _sequence = DOTween.Sequence();

        AnimateIcon();

        _sequence.SetLoops(-1);
    }

    private void AnimateIcon()
    {
        _sequence.Append(transform.DOLocalRotate(_rotationVector, _duration));

        for (int i = 0; i < _rotations; ++i)
        {
            _sequence.Append(transform.DOLocalRotate(-_rotationVector, _duration));
            _sequence.Append(transform.DOLocalRotate(_rotationVector, _duration));
        }

        _sequence.Append(transform.DOLocalRotate(Vector3.zero, _duration));
        _sequence.AppendInterval(_coolDown);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _sequence.Kill();
        transform.rotation = Quaternion.identity;
    }
}