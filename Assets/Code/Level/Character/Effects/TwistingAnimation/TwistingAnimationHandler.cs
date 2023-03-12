using DG.Tweening;
using UnityEngine;

public class TwistingAnimationHandler : ISubscriber, IInitializable, IRestart
{
    private readonly TwistingAnimation _portalAnimation;
    private readonly TweenCallback _onRespawn;
    private readonly WinState _winState;

    public TwistingAnimationHandler(SpriteRenderer spriteRenderer, WinState winState, AnimationCurve fadeCurve, TweenCallback onRespawn)
    {
        _portalAnimation = new TwistingAnimation(spriteRenderer, fadeCurve);
        _onRespawn = onRespawn;
        _winState = winState;
    }
    
    void IInitializable.Initialize()
    {
        Restart();
    }

    void ISubscriber.Subscribe()
    {
        _winState.Entered += _portalAnimation.FadeOut;
    }

    void ISubscriber.Unsubscribe()
    {
        _winState.Entered -= _portalAnimation.FadeOut;
    }

    public void Restart()
    {
        _portalAnimation.FadeIn().OnComplete(_onRespawn);
    }
}