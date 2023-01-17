using DG.Tweening;
using UnityEngine;

public class SpriteTransparency
{
    private readonly SpriteRenderer _spriteRenderer;

    public SpriteTransparency(SpriteRenderer spriteRenderer)
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
        SmoothlyChangeAlpha(0, 0);
    }

    private void SmoothlyChangeAlpha(float alpha, float duration)
    {
        _spriteRenderer.DOFade(alpha, duration);
    }
}