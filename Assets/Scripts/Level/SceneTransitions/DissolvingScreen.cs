using Coffee.UIEffects;
using DG.Tweening;
using UnityEngine;


public class DissolvingScreen : LoadingScreen
{
    [SerializeField] private UIDissolve _uiDissolve;


    public override Tween Appear()
    {
        return DOTween.To(x => _uiDissolve.effectFactor = x, _uiDissolve.effectFactor, 0, Duration);
    }

    
    public override Tween Disappear()
    {
        return DOTween.To(x => _uiDissolve.effectFactor = x, _uiDissolve.effectFactor, 1, Duration);
    }
}