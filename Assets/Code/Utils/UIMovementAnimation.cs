using System.Collections;
using DG.Tweening;
using UnityEngine;


public class UIMovementAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform _target;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _delay;
    [SerializeField] private float _duration = 2f;
    private Tween _animation;
    
    
    private IEnumerator Start()
    {
        yield return null;
        yield return new WaitForSeconds(_delay);
        
        _animation = transform.DOMove(_target.position, _duration).SetEase(_curve);
    }


    private void OnDestroy()
    {
        _animation.Kill();
    }
}
