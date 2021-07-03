using System.Collections;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class Backstage : MonoBehaviour
{
    [SerializeField] private float _fadingSpeed = 2f;
    [SerializeField] private float _brightenSpeed = 1.5f;
    [SerializeField] private Image _image = null;


    public IEnumerator MakeFade(IEnumerator backstageAction)
    {
        yield return StartCoroutine(ChangeAlphaChannel(_fadingSpeed , true)); // dark 

        yield return StartCoroutine(backstageAction);

        yield return StartCoroutine(ChangeAlphaChannel(_brightenSpeed , false)); // transparent
    }


    private IEnumerator ChangeAlphaChannel(float fadingSpeed , bool becomeOpaque)
    {
        float alphaChannel = becomeOpaque ? 0 : 1;
        fadingSpeed *= becomeOpaque ? 1 : -1;

        while (becomeOpaque ? alphaChannel <= 1 : alphaChannel >= 0)
        {
            alphaChannel += fadingSpeed * Time.deltaTime;
            _image.color = new Color(255, 255, 255, alphaChannel);
            yield return new WaitForFixedUpdate();
        }
    }
}
