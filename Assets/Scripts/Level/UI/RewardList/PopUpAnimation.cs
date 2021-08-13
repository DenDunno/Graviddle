using DG.Tweening;
using UnityEngine;


public class PopUpAnimation
{
    private readonly float _animationDuration = 2f;
    private readonly Transform _transform = null;
    private readonly Vector3 _startScale;
    

    public PopUpAnimation(Transform transform)
    {
        _transform = transform;
        _startScale = transform.localScale;
    }


    public Tween ShowUI()
    {
        return _transform.DOScale(Vector3.zero, _animationDuration);
    }


    public Tween HideUI()
    {
        return _transform.DOScale(_startScale, _animationDuration);
    }
}
