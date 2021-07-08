using UnityEngine;


public class CharacterTransparency : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer = null;
    private readonly float _fadingSpeed = 1f;
    private readonly ScreenFading _screenFading = new ScreenFading();


    public void BecomeOpaque()
    {
        StartCoroutine(_screenFading.ChangeAlphaChannel(_fadingSpeed , true , SetSpriteAlpaChannel));
    }


    public void BecomeTransparent()
    {
        StartCoroutine(_screenFading.ChangeAlphaChannel(_fadingSpeed , false , SetSpriteAlpaChannel));
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
