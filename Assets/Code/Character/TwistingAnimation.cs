using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class TwistingAnimation : ISubscriber, IInitializable, IRestart
{
    private readonly SpriteRenderer _spriteRenderer;
    private readonly AnimationCurve _fadeCurve;
    private readonly float _duration = 3f;
    private readonly float _waitTime = 1f;
    private readonly WinState _winState;

    public TwistingAnimation(SpriteRenderer spriteRenderer, WinState winState, AnimationCurve fadeCurve)
    {
        _spriteRenderer = spriteRenderer;
        _fadeCurve = fadeCurve;
        _winState = winState;
    }

    void IInitializable.Initialize()
    {
        Restart();
    }

    void ISubscriber.Subscribe()
    {
        _winState.Entered += Play;
    }

    void ISubscriber.Unsubscribe()
    {
        _winState.Entered -= Play;
    }

    private void Show()
    {
        
    }

    private void Hide()
    {
        SetFloat(CharacterShaderID.WaveStrength, 0.08f);
        SetFloat(CharacterShaderID.WaveSpeed, 2f);
    }

    private async void Play()
    {
        _spriteRenderer.material.SetFloat(CharacterShaderID.WaveStrength, 0.08f);
        _spriteRenderer.material.SetFloat(CharacterShaderID.WaveSpeed, 2f);
        
        await UniTask.Delay(TimeSpan.FromSeconds(_waitTime));

        float time = 0;

        while (time < _duration)
        {
            time += Time.deltaTime;
            SetValue(time / _duration);
            
            await UniTask.Yield();
        }
    }

    private void SetValue(float value)
    {
        SetFloat(CharacterShaderID.HSV, Mathf.Lerp(0, 270, EaseFunctions.OutQuart(value)));
        SetFloat(CharacterShaderID.Rotation, Mathf.Lerp(0, Mathf.PI * 2, value));
        SetFloat(CharacterShaderID.Twist, Mathf.Lerp(0, Mathf.PI / 2f, value));
        SetFloat(CharacterShaderID.Alpha, _fadeCurve.Evaluate(value));
        SetScale(Mathf.Lerp(0.75f, 1f, EaseFunctions.InCirc(1 - value)));
    }

    public async void Restart()
    {
        SetFloat(CharacterShaderID.Alpha, 0);
        SetFloat(CharacterShaderID.WaveStrength, 1);
        SetFloat(CharacterShaderID.WaveSpeed, 1);

        await UniTask.Delay(TimeSpan.FromSeconds(_waitTime));
        
        DOTween.To(x =>
        {
            SetFloat(CharacterShaderID.Alpha, x);
            SetFloat(CharacterShaderID.WaveStrength, 1 - x);
            SetFloat(CharacterShaderID.Rotation, Mathf.Lerp(0, Mathf.PI * 2, x));
            SetFloat(CharacterShaderID.HSV, Mathf.Lerp(0, 270, 1 - x));
            SetScale(Mathf.Lerp(0.25f, 1f, EaseFunctions.InCirc(x)));
        }, 0, 1, 2);
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