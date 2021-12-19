using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(RectTransform))]
public class IconAnimation : MonoBehaviour, IPointerClickHandler
{
    private readonly float _duration = 0.13f;
    private readonly float _coolDown = 1.2f;
    private readonly int _rotations = 2;
    private readonly Vector3 _rotationVector = new Vector3(0, 0, -25);
    private Sequence _sequence;
    

    private void Start()
    {
        _sequence = DOTween.Sequence();

        AnimateIcon(GetComponent<RectTransform>());

        _sequence.SetLoops(-1);
    }


    private void AnimateIcon(RectTransform iconTransform)
    {
        _sequence.Append(iconTransform.DOLocalRotate(_rotationVector, _duration));

        for (int i = 0; i < _rotations; ++i)
        {
            _sequence.Append(iconTransform.DOLocalRotate(-_rotationVector, _duration));
            _sequence.Append(iconTransform.DOLocalRotate(_rotationVector, _duration));
        }

        _sequence.Append(iconTransform.DOLocalRotate(Vector3.zero, _duration));
        _sequence.AppendInterval(_coolDown);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        _sequence.Kill();
        transform.rotation = Quaternion.identity;
    }
}