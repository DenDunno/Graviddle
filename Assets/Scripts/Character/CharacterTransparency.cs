using DG.Tweening;
using UnityEngine;


public class CharacterTransparency : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer = null;


    public void BecomeOpaque()
    {
        SmoothlyChangeAlpha(255, 1);
    }


    public void BecomeTransparent()
    {
        SmoothlyChangeAlpha(0, 1);
    }


    public void BecomeTransparentNow()
    {
        SmoothlyChangeAlpha(0 , 0);
    }


    private void SmoothlyChangeAlpha(float alpha , float duration)
    {
        _spriteRenderer.DOFade(alpha, duration);
    }
}
