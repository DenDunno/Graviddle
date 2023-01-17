using Coffee.UIEffects;
using DG.Tweening;
using UnityEngine;

public class WoodPointerAnimation : MonoBehaviour
{
    [SerializeField] private UIDissolve _dissolveImage;
    [SerializeField] private float _waitTime;
    private const float _duration = 2f;
    private const float _dissolveStartValue = 0;
    private const float _dissolveTargetValue = 1;
    
    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.GetComponent<Character>() != null)
        {
            ShowImage();
        }
    }

    private void ShowImage()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(_waitTime);
        sequence.Append(DOTween.To(x => _dissolveImage.effectFactor = x, _dissolveStartValue, _dissolveTargetValue, _duration));
            
        sequence.onComplete += ()=>
        {
            _dissolveImage.gameObject.SetActive(false);
        };
    }
}