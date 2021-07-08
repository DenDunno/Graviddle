using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Backstage : MonoBehaviour
{
    [SerializeField] private float _fadingSpeed = 2f;
    [SerializeField] private float _brightenSpeed = 1.5f;
    [SerializeField] private Image _image = null;

    private readonly ScreenFading _screenFading = new ScreenFading();


    public IEnumerator MakeFade(IEnumerator backstageAction)
    {
        yield return StartCoroutine(_screenFading.ChangeAlphaChannel(_fadingSpeed , true , SetImageAlphaChaneel)); // dark 

        yield return StartCoroutine(backstageAction);

        yield return StartCoroutine(_screenFading.ChangeAlphaChannel(_brightenSpeed , false , SetImageAlphaChaneel)); // transparent
    }


    private void SetImageAlphaChaneel(float alphaChannel)
    {
        _image.color = new Color(255, 255, 255, alphaChannel);
    }
}
