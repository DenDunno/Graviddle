using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class FadingScreen : LoadingScreen
{
    [SerializeField] private Image _loadingImage;


    public override Tween Appear()
    {
        return _loadingImage.DOFade(1, Duration);
    }

    
    public override Tween Disappear()
    {
        return _loadingImage.DOFade(0, Duration);
    }
}