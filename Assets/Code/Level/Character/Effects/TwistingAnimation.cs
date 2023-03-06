using DG.Tweening;
using UnityEngine;

public class TwistingAnimation : ISubscriber, IInitializable, IRestart
{
    private readonly SpriteRenderer _spriteRenderer;
    private readonly AnimationCurve _fadeCurve;
    private readonly float _fadeDuration = 5f;
    private readonly float _brightenDuration = 2f;
    private readonly float _waitTime = 1f;
    private readonly WinState _winState;
    private Sequence _animation;
    
    public TwistingAnimation(SpriteRenderer spriteRenderer, WinState winState, AnimationCurve fadeCurve)
    {
        _spriteRenderer = spriteRenderer;
        _fadeCurve = fadeCurve;
        _winState = winState;
    }

    private Tween FadeAnimation => DOTween.To(value =>
    {
        SetFloat(CharacterShaderID.HSV, Mathf.Lerp(0, 270, EaseFunctions.OutQuart(value)));
        SetFloat(CharacterShaderID.Rotation, Mathf.Lerp(0, Mathf.PI * 2, value));
        SetFloat(CharacterShaderID.Twist, Mathf.Lerp(0, Mathf.PI / 2f, value));
        SetFloat(CharacterShaderID.Alpha, _fadeCurve.Evaluate(value));
        SetScale(Mathf.Lerp(0.75f, 1f, EaseFunctions.InCirc(1 - value)));
    }, 0, 1, _fadeDuration);
    
    private Tween BrightenAnimation => DOTween.To(x =>
    {
        SetFloat(CharacterShaderID.HSV, Mathf.Lerp(0, 270, 1 - x));
        SetFloat(CharacterShaderID.Rotation, Mathf.Lerp(0, Mathf.PI * 2, x));
        SetFloat(CharacterShaderID.WaveStrength, 1 - x);
        SetFloat(CharacterShaderID.Alpha, x);
        SetScale(Mathf.Lerp(0.25f, 1f, EaseFunctions.InCirc(x)));
    }, 0, 1, _brightenDuration);

    void IInitializable.Initialize()
    {
        Show();
    }

    void ISubscriber.Subscribe()
    {
        _winState.Entered += Hide;
    }

    void ISubscriber.Unsubscribe()
    {
        _winState.Entered -= Hide;
    }

    private void Hide()
    {
        SetWave(0.08f, 2f);
        PlayAnimation(FadeAnimation);
    }

    private void Show()
    {
        SetWave(0f, 1f);
        SetFloat(CharacterShaderID.Alpha, 0);
        PlayAnimation(BrightenAnimation);
    }

    private void PlayAnimation(Tween animation)
    {
        _animation?.Kill();
        _animation = DOTween.Sequence();
        _animation.AppendInterval(_waitTime);
        _animation.Append(animation);
    }

    public void Restart()
    {
        Show();
    }

    private void SetWave(float strength, float speed)
    {
        SetFloat(CharacterShaderID.WaveStrength, strength);
        SetFloat(CharacterShaderID.WaveSpeed, speed);
    }
    
    private void SetFloat(int id, float value)
    {
        _spriteRenderer.material.SetFloat(id, value);
    }

    private void SetScale(float scale)
    {
        _spriteRenderer.transform.SetScale(scale);
    }
}