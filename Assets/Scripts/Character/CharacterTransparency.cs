using System.Collections;
using UnityEngine;


public class CharacterTransparency : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer = null;
    private readonly float _fadingSpeed = 1f;


    public void BecomeOpaque()
    {
        StartCoroutine(ChangeAlphaChannel(true));
    }


    public void BecomeTransparent()
    {
        StartCoroutine(ChangeAlphaChannel(false));
    }


    public void BecomeTransparentNow() 
    {
        _spriteRenderer.color = new Color(255, 255, 255, 0);
    }


    private IEnumerator ChangeAlphaChannel(bool becomeOpaque)
    {
        float alphaChannel = becomeOpaque ? 0 : 1;
        float fadingSpeed = _fadingSpeed * (becomeOpaque ? 1 : -1);

        while (becomeOpaque ? alphaChannel <= 1 : alphaChannel >= 0)
        {
            alphaChannel += fadingSpeed * Time.deltaTime;
            _spriteRenderer.color = new Color(255, 255, 255, alphaChannel);
            yield return new WaitForFixedUpdate();
        }
    }
}
