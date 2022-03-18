using DG.Tweening;
using UnityEngine;


public class StarAnimation : MonoBehaviour
{
    private const float _scaleFrom = 0.85f;
    private const float _scaleTo = 1f;
    private const float _duration = 0.5f;


    private void Start()
    {
        Sequence scaleAnimation = DOTween.Sequence();

        scaleAnimation.Append(ScaleStar(_scaleFrom));
        scaleAnimation.Append(ScaleStar(_scaleTo));

        scaleAnimation.SetLoops(-1);
    }


    private Tween ScaleStar(float targetScale)
    {
        return transform.DOScale(Vector3.one * targetScale, _duration).SetEase(Ease.InOutSine);
    }
}