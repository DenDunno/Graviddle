using System.Collections;
using DG.Tweening;
using UnityEngine;
using System;


[Serializable]
public class LaserLineSwitcher
{
    [SerializeField] private LaserDistortion _laserDistortion;
    private LaserDistortionData _distortionData = new LaserDistortionData();
    private Tween _switchingTween;


    public void Init()
    {
        _laserDistortion.Init();
    }


    public IEnumerator ToggleLaserLine(bool activateLaser)
    {
        float duration = _distortionData.GetDistortionDuration(activateLaser);
        float targetDistortion = _distortionData.GetDistortion(activateLaser);
        float startDistortion = _distortionData.GetDistortion(activateLaser == false);

        _switchingTween = DOTween.To(x => _laserDistortion.SetDistortion(x), startDistortion, targetDistortion, duration);

        yield return _switchingTween.WaitForCompletion();
    }


    public void Restart(bool startOnAwake)
    {
        _switchingTween?.Kill();
        _laserDistortion.SetDistortion(_distortionData.GetDistortion(startOnAwake));
    }
}