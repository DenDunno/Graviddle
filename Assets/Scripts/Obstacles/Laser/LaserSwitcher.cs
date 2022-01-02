using System.Collections;
using UnityEngine;
using System;


public class LaserSwitcher : MonoBehaviour
{
    [SerializeField] private LaserParticlesSwitcher _laserParticlesSwitcher = null;
    [SerializeField] private LaserLineSwitcher _laserLineSwitcher = null;
    private InvocationWithDelay _particlesToggling;
    private InvocationWithDelay _laserTogglingEvent;

    public event Action<bool> LaserToggled;


    public void Init(bool startOnAwake)
    {
        _laserTogglingEvent = new InvocationWithDelay(0.5f, 2f, activate => LaserToggled?.Invoke(activate));
        _particlesToggling = new InvocationWithDelay(0.7f, 1f, _laserParticlesSwitcher.ToggleParticles);

        _laserLineSwitcher.Init();
       Restart(startOnAwake);
    }


    public IEnumerator ToggleLaser(bool activateLaser)
    {
        StartCoroutine(_laserTogglingEvent.Invoke(activateLaser));
        StartCoroutine(_particlesToggling.Invoke(activateLaser));
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