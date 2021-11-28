using Coffee.UIEffects;
using DG.Tweening;
using UnityEngine;


public class WoodPointer : MonoBehaviour
{
    [SerializeField] private UIDissolve _dissolveImage = null;


    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.TryGetComponent(out Character character))
        {
            ShowImage();
        }
    }


    private void ShowImage()
    {
        const float duration = 2f;
        const float fromFactor = 0;
        const float toFactor = 1f;

        DOTween.To(x => _dissolveImage.effectFactor = x, fromFactor, toFactor, duration).onComplete += ()=>
        {
            _dissolveImage.gameObject.SetActive(false);
        };
    }
}