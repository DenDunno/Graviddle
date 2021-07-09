using UnityEngine;
using System;


[Serializable]
public class CharacterTransparency 
{
    [SerializeField] private SpriteRenderer _spriteRenderer = null;
    [SerializeField] private ImageFading _imageFading = null;


    public void BecomeOpaque(MonoBehaviour character)
    {
        character.StartCoroutine(_imageFading.ChangeAlphaChannel(true , SetSpriteAlpaChannel));
    }


    public void BecomeTransparent(MonoBehaviour character)
    {
        character.StartCoroutine(_imageFading.ChangeAlphaChannel(false , SetSpriteAlpaChannel));
    }


    public void BecomeTransparentNow() 
    {
        SetSpriteAlpaChannel(0);
    }


    private void SetSpriteAlpaChannel(float alphaChannel)
    {
        _spriteRenderer.color = new Color(255, 255, 255, alphaChannel);
    }
}
