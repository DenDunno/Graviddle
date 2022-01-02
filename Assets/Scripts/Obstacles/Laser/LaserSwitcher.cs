using System.Collections;
using UnityEngine;
using System;


public class LaserSwitcher : MonoBehaviour
{
    [SerializeField] private LaserParticlesSwitcher _laserParticlesSwitcher = null;
    [SerializeField] private LaserLineSwitcher _laserLineSwitcher = null;
    private InvocationWithDelay _particlesTogglingWithDelay;
    private InvocationWithDelay _laserTogglingEventWithDelay;

    public event Action<bool> LaserToggled;


    public void Init(bool startOnAwake)
    {
        _laserTogglingEventWithDelay = new InvocationWithDelay(0.5f, 2f, activate => LaserToggled?.Invoke(activate));
        _particlesTogglingWithDelay = new InvocationWithDelay(0.7f, 1f, _laserParticlesSwitcher.ToggleParticles);

        _laserLineSwitcher.Init();
       Restart(startOnAwake);
    }


    public IEnumerator ToggleLaser(bool activateLaser)
    {
        StartCoroutine(_laserTogglingEventWithDelay.Invoke(activateLaser));
        StartCoroutine(_particlesTogglingWithDelay.Invoke(activateLaser));
        yield return StartCoroutine(_laserLineSwitcher.ToggleLaserLine(activateLaser));
    }


    public void Restart(bool startOnAwake)
    {
        StopAllCoroutines();
        LaserToggled?.Invoke(startOnAwake);
        _laserLineSwitcher.Restart(startOnAwake);
        _laserParticlesSwitcher.ToggleParticles(startOnAwake);
    }
}