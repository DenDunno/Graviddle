using System.Collections;
using Coffee.UIEffects;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class Backstage : MonoBehaviour
{
    [SerializeField] private bool _useDissolve;
    [SerializeField] private Image _image;
    [SerializeField] private UIDissolve _dissolveImage;
    [SerializeField] private float _fadingTime = 1f;


    public IEnumerator MakeTransition(IEnumerator backstageAction)
    {
        yield return (_useDissolve ? MakeDissolve(1, 0) : MakeFade(1)).WaitForCompletion();

        yield return StartCoroutine(backstageAction);

        yield return (_useDissolve ? MakeDissolve(0, 1) : MakeFade(0)).WaitForCompletion();
    }


    private Tween MakeDissolve(float fromEffectFactor, float toEffectFactor)
    {
        return DOTween.To(x => _dissolveImage.effectFactor = x, fromEffectFactor, toEffectFactor, _fadingTime);
    }


    public Tween MakeFade(float targetAlpha)
    {
        return _image.DOFade(targetAlpha, _fadingTime);
    }
}
