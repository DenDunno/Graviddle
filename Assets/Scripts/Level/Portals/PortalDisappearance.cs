using System;
using DG.Tweening;
using UnityEngine;


[Serializable]
public class PortalDisappearance 
{
    [SerializeField] private ParticleSystem _disappearFX;
    [SerializeField] private float _disappearingSpeed;
    [SerializeField] private MonoBehaviour _context;
    private const float _timeBeforeDisappearance = 1.3f;
    private Tween _currentAnimation;


    public void Disappear()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(_timeBeforeDisappearance);
        sequence.Append(ScalePortal()).AppendCallback(PlayDustAnimation);
        sequence.AppendInterval(_timeBeforeDisappearance);
        sequence.OnComplete(()=> _context.gameObject.SetActive(false));
        
        _currentAnimation = sequence;
    }


    private Tween ScalePortal()
    {
        return _context.transform.DOScale(Vector3.zero, _disappearingSpeed).SetEase(Ease.OutQuint);
    }
    
    
    private void PlayDustAnimation()
    {
        _disappearFX.Play();
    }


    public void ResetAnimation()
    {
        _currentAnimation?.Kill();

        _context.gameObject.SetActive(true);
        _context.transform.localScale = Vector3.one;
    }
}