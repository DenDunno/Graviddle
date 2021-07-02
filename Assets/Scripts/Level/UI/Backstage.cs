using System.Collections;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class Backstage : MonoBehaviour
{
    private readonly float _fadingSpeed = 2f;
    private Image _image;
    

    private void Start()
    {
        _image = GetComponent<Image>();
    }


    public IEnumerator MakeFade(IEnumerator backstageAction)
    {
        yield return StartCoroutine(ChangeAlphaChannel(true)); // dark 

        yield return StartCoroutine(backstageAction);

        yield return StartCoroutine(ChangeAlphaChannel(false)); // transparent
    }


    private IEnumerator ChangeAlphaChannel(bool transparent)
    {
        float alphaChannel = transparent ? 0 : 1;
        var fadingSpeed = _fadingSpeed * (transparent ? 1 : -1);

        while (transparent ? alphaChannel <= 1 : alphaChannel >= 0)
        {
            alphaChannel += fadingSpeed * Time.deltaTime;
            _image.color = new Color(255, 255, 255, alphaChannel);
            yield return new WaitForFixedUpdate();
        }
    }
}
