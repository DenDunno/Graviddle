using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class Backstage : MonoBehaviour
{
    [SerializeField] private Image _image = null;
    [SerializeField] private float _fadingSpeed = 1f;
    [SerializeField] private float _brightenSpeed = 1f;


    public IEnumerator MakeFade(IEnumerator backstageAction)
    {
        yield return _image.DOFade(1, _fadingSpeed).WaitForCompletion();

        yield return StartCoroutine(backstageAction);

        yield return _image.DOFade(0, _brightenSpeed).WaitForCompletion();
    }
}
