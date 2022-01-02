using System.Collections;
using DG.Tweening;
using UnityEngine;
using System;


public class LaserSwitcher : MonoBehaviour
{
    [SerializeField] private LaserDistortion _laserDistortion = null;
    [SerializeField] private LaserParticlesSwitcher _laserParticlesSwitcher = null;
    private LaserDistortionData _distortionData = new LaserDistortionData();

    public event Action<bool> LaserToggled;


    public void Init(bool startOnAwake)
    {
        _laserDistortion.Init();
        _laserDistortion.SetDistortion(_distortionData.GetDistortion(startOnAwake));
        _laserParticlesSwitcher.ToggleParticlesNow(startOnAwake);
    }


    public IEnumerator ToggleLaser(bool activateLaser)
    {
        float targetDistortion = _distortionData.GetDistortion(activateLaser);
        float startDistortion = _distortionData.GetDistortion(activateLaser == false);
        float duration = _distortionData.GetDistortionDuration(activateLaser);

        _laserParticlesSwitcher.ToggleParticlesWithDelay(activateLaser);

        yield return DOTween.To(x => _laserDistortion.SetDistortion(x), startDistortion, targetDistortion, duration)
                            .WaitForCompletion();

        LaserToggled?.Invoke(activateLaser);
    }
}