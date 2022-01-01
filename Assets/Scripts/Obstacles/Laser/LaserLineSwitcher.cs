using DG.Tweening;
using UnityEngine;
using System;


[Serializable]
public class LaserLineSwitcher
{
    [SerializeField] private Renderer _renderer = null;
    private MaterialPropertyBlock _propertyBlock;
    private int _noiseAmountId;
    private int _noisePowerId;
    private Tween _animation;


    public void Init()
    {
        _noiseAmountId = Shader.PropertyToID("_NoiseAmount");
        _noisePowerId = Shader.PropertyToID("_NoisePower");
        _propertyBlock = new MaterialPropertyBlock();
        _renderer.GetPropertyBlock(_propertyBlock);
    }


    public Tween SmoothlyToggleLaserLine(bool activate)
    {
        SetProperty(_noisePowerId, GetNoisePower(activate));

        float noiseAmountFrom = GetNoiseAmount(activate == false);
        float noiseAmountTo = GetNoiseAmount(activate);
        float duration = GetDuration(activate);

        _animation = DOTween.To(x => SetProperty(_noiseAmountId, x), noiseAmountFrom, noiseAmountTo, duration);

        return _animation;
    }


    private void SetProperty(int id, float value)
    {
        _propertyBlock.SetFloat(id, value);
        _renderer.SetPropertyBlock(_propertyBlock);
    }


    public void StopAnimation()
    {
        _animation?.Kill();
    }


    private float GetNoiseAmount(bool activated) => activated ?  0.25f : 1f;
    private float GetNoisePower(bool activated) => activated ? 2f : 6f;
    private float GetDuration(bool activated) => activated ? 2.5f : 1.5f;
}