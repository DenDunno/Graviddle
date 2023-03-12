using DG.Tweening;
using UnityEngine;

public class TwistingAnimation
{
    private readonly TwistingAnimationData _data = new();
    private readonly SpriteRenderer _spriteRenderer;
    private readonly AnimationCurve _fadeCurve;
    private Sequence _animation;
    
    public TwistingAnimation(SpriteRenderer spriteRenderer, AnimationCurve fadeCurve)
    {
        _spriteRenderer = spriteRenderer;
        _fadeCurve = fadeCurve;
    }

    private Tween FadeAnimation => DOTween.To(value =>
    {
        SetFloat(_data.HSV, Mathf.Lerp(0, 270, EaseFunctions.OutQuart(value)));
        SetFloat(_data.Rotation, Mathf.Lerp(0, Mathf.PI * 2, value));
        SetFloat(_data.Twist, Mathf.Lerp(0, Mathf.PI / 2f, value));
        SetFloat(_data.Alpha, _fadeCurve.Evaluate(value));
        SetScale(Mathf.Lerp(0.75f, 1f, EaseFunctions.InCirc(1 - value)));
    }, 0, 1, _data.FadeDuration);

    private Tween BrightenAnimation => DOTween.To(x =>
    {
        SetFloat(_data.HSV, Mathf.Lerp(0, 270, 1 - x));
        SetFloat(_data.Rotation, Mathf.Lerp(0, Mathf.PI * 2, x));
        SetFloat(_data.WaveStrength, 1 - x);
        SetFloat(_data.Alpha, x);
        SetScale(Mathf.Lerp(0.25f, 1f, EaseFunctions.InCirc(x)));
    }, 0, 1, _data.BrightenDuration);

    public void FadeOut()
    {
        SetWave(0.08f, 2f);
        PlayAnimation(FadeAnimation);
    }

    public Tween FadeIn()
    {
        SetWave(0f, 1f);
        SetFloat(_data.Alpha, 0);
        return PlayAnimation(BrightenAnimation);
    }

    private void SetWave(float strength, float speed)
    {
        SetFloat(_data.WaveStrength, strength);
        SetFloat(_data.WaveSpeed, speed);
    }

    private void SetFloat(int id, float value)
    {
        _spriteRenderer.material.SetFloat(id, value);
    }

    private void SetScale(float scale)
    {
        _spriteRenderer.transform.SetScale(scale);
    }

    private Tween PlayAnimation(Tween animation)
    {
        _animation?.Kill();
        _animation = DOTween.Sequence();
        _animation.AppendInterval(_data.WaitTime);
        _animation.Append(animation);
        _animation.SetLink(_spriteRenderer.gameObject);

        return _animation;
    }
}