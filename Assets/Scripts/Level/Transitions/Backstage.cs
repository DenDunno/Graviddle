using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Backstage : MonoBehaviour
{
    [SerializeField] private Image _image = null;
    [SerializeField] private ImageFading _imageFading = null;


    public IEnumerator MakeFade(IEnumerator backstageAction)
    {
        yield return StartCoroutine(_imageFading.ChangeAlphaChannel(true , SetImageAlphaChannel)); // dark 

        yield return StartCoroutine(backstageAction);

        yield return StartCoroutine(_imageFading.ChangeAlphaChannel(false , SetImageAlphaChannel)); // transparent
    }


    private void SetImageAlphaChannel(float alphaChannel)
    {
        _image.color = new Color(255, 255, 255, alphaChannel);
    }
}
