using UnityEngine;
using System;


[Serializable]
public class CharacterTransparency 
{
    [SerializeField] private SpriteRenderer _spriteRenderer = null;
    [SerializeField] private ImageFading _imageFading = null;


    public void BecomeOpaque(MonoBehaviour character)
    {
        character.StartCoroutine(_imageFading.ChangeAlphaChannel(true , SetSpriteAlphaChannel));
    }


    public void BecomeTransparent(MonoBehaviour character)
    {
        character.StartCoroutine(_imageFading.ChangeAlphaChannel(false , SetSpriteAlphaChannel));
    }


    public void BecomeTransparentNow() 
    {
        SetSpriteAlphaChannel(0);
    }


    private void SetSpriteAlphaChannel(float alphaChannel)
    {
        _spriteRenderer.color = new Color(255, 255, 255, alphaChannel);
    }
}
