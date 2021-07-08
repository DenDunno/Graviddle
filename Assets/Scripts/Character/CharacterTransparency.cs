using UnityEngine;


public class CharacterTransparency : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer = null;
    [SerializeField] private ScreenFading _screenFading = null;


    public void BecomeOpaque()
    {
        StartCoroutine(_screenFading.ChangeAlphaChannel(true , SetSpriteAlpaChannel));
    }


    public void BecomeTransparent()
    {
        StartCoroutine(_screenFading.ChangeAlphaChannel(false , SetSpriteAlpaChannel));
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
