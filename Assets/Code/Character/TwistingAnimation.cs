using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class TwistingAnimation : ISubscriber
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

    void ISubscriber.Subscribe()
    {
        _winState.Entered += Play;
    }

    void ISubscriber.Unsubscribe()
    {
        _winState.Entered -= Play;
    }

    private async void Play()
    {
        _spriteRenderer.material.EnableKeyword("ROUNDWAVEUV_ON");
        
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
        _spriteRenderer.material.SetFloat(CharacterShaderID.HSV, Mathf.Lerp(0, 270, EaseFunctions.OutQuart(value)));
        _spriteRenderer.material.SetFloat(CharacterShaderID.Rotation, Mathf.Lerp(0, Mathf.PI * 2, value));
        _spriteRenderer.material.SetFloat(CharacterShaderID.Twist, Mathf.Lerp(0, Mathf.PI / 2f, value));
        _spriteRenderer.material.SetFloat(CharacterShaderID.Alpha, _fadeCurve.Evaluate(value));
        _spriteRenderer.transform.SetScale(Mathf.Lerp(0.75f, 1f, EaseFunctions.InCirc(1 - value)));
    }
}