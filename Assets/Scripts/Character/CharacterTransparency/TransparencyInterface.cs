using DG.Tweening;
using UnityEngine;


public class TransparencyInterface
{
    private readonly SpriteRenderer _spriteRenderer;


    public TransparencyInterface(SpriteRenderer spriteRenderer)
    {
        _spriteRenderer = spriteRenderer;
    }


    public void StopAnimation()
    {
        _spriteRenderer.DOKill();
    }


    public void BecomeOpaque()
    {
        SmoothlyChangeAlpha(1, 2);
    }


    public void BecomeTransparent()
    {
        SmoothlyChangeAlpha(0, 1);
    }


    public void BecomeTransparentNow()
    {
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 0);
    }


    private void SmoothlyChangeAlpha(float alpha, float duration)
    {
        _spriteRenderer.DOFade(alpha, duration);
    }
}
