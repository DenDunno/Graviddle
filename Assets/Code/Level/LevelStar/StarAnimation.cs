using DG.Tweening;
using UnityEngine;

public class StarAnimation : MonoBehaviour
{
    private const float _scaleFrom = 0.85f;
    private const float _scaleTo = 1f;
    private const float _duration = 0.5f;
    private Sequence _animation;
    
    private void Start()
    {
        _animation = DOTween.Sequence();

        _animation.Append(ScaleStar(_scaleFrom));
        _animation.Append(ScaleStar(_scaleTo));

        _animation.SetLoops(-1);
    }

    private Tween ScaleStar(float targetScale)
    {
        return transform.DOScale(Vector3.one * targetScale, _duration).SetEase(Ease.InOutSine);
    }

    private void OnDestroy()
    {
        _animation.Kill();
    }
}