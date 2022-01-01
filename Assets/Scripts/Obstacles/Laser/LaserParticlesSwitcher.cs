using System;
using Cysharp.Threading.Tasks;
using UnityEngine;


[Serializable]
public class LaserParticlesSwitcher
{
    [SerializeField] private ParticleSystem[] _particles = null;


    public void ToggleParticlesNow(bool activate)
    {
        ToggleParticles(activate, false);
    }


    public void ToggleParticlesWithDelay(bool activate)
    {
        ToggleParticles(activate, true);
    }


    private async void ToggleParticles(bool activate, bool withDelay)
    {
        if (withDelay)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(GetDelayTime(activate)));
        }

        foreach (ParticleSystem particle in _particles)
        {
            ParticleSystem.EmissionModule emission = particle.emission;
            emission.enabled = activate;
        }
    }


    private float GetDelayTime(bool activate)
    {
        return activate ? 0.2f : 0.6f;
    } 
}