using DG.Tweening;
using UnityEngine;


public class PortalDisappearance 
{
    private readonly float _timeBeforeDisappearance = 1.3f;
    private readonly float _disappearingSpeed;
    private readonly MonoBehaviour _context;
    private Tween _currentAnimation;


    public PortalDisappearance(float disappearingSpeed, MonoBehaviour context)
    {
        _context = context;
        _disappearingSpeed = disappearingSpeed;
    }


    public void Disappear()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(_timeBeforeDisappearance);
        sequence.Append(ScalePortal()).AppendCallback(() =>
        {
            _context.gameObject.SetActive(false);
        });

        _currentAnimation = sequence;
    }


    private Tween ScalePortal()
    {
        return _context.transform.DOScale(Vector3.zero, _disappearingSpeed).SetEase(Ease.OutQuint);

    }


    public void StopAndResetAnimation()
    {
        _currentAnimation?.Kill();

        _context.gameObject.SetActive(true);
        _context.transform.localScale = Vector3.one;
    }
}