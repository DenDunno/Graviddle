using System;
using UnityEngine;


[Serializable]
public class LaserParticlesSwitcher
{
    [SerializeField] private ParticleSystem[] _particles;


    public void ToggleParticles(bool activate)
    {
        foreach (ParticleSystem particle in _particles)
        {
            ParticleSystem.EmissionModule emission = particle.emission;
            emission.enabled = activate;
        }
    }
}