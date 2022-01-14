using Coffee.UIEffects;
using DG.Tweening;
using UnityEngine;


public class WoodPointer : MonoBehaviour
{
    [SerializeField] private UIDissolve _dissolveImage;
    [SerializeField] private float _waitTime;

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
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(_waitTime);
        sequence.Append(DOTween.To(x => _dissolveImage.effectFactor = x, fromFactor, toFactor, duration));
            
        sequence.onComplete += ()=>
        {
            _dissolveImage.gameObject.SetActive(false);
        };
    }
}