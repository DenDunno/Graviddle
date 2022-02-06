using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AddressableAssets;


[Serializable]
public class PortalDisappearance
{
    [SerializeField] private AssetReference _portalDisappearFXReference;
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
        ParticlesHelper.PlayAndDestroy(_portalDisappearFXReference, _context.transform);
    }


    public void ResetAnimation()
    {
        _currentAnimation?.Kill();

        _context.gameObject.SetActive(true);
        _context.transform.localScale = Vector3.one;
    }
}