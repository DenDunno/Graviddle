using UnityEngine;
using System;


[Serializable]
public class LaserSourceEffectsAdjuster
{
    [SerializeField] private ParticleSystem _sourceFlame;
    [SerializeField] private ParticleSystem _sourceSparks;
    [SerializeField] private bool _applyEffectsAdjustment = true;
    

    public void ConfigureSourceEffects(float laserDistance)
    {
        if (_applyEffectsAdjustment)
        {
            ParticleSystem.MainModule sparksMain = _sourceSparks.main;
            ParticleSystem.MainModule flameMain = _sourceFlame.main;

            sparksMain.startLifetime = EvaluateSparksLifeTime(laserDistance);
            sparksMain.startSpeed = EvaluateSparksSpeed(laserDistance);
            flameMain.startLifetime = EvaluateFlameLifeTime(laserDistance);
            _sourceFlame.transform.localPosition = EvaluateFlamePosition(laserDistance);
        }
    }


    private float EvaluateSparksLifeTime(float laserDistance)
    {
        return 0.00362f * laserDistance + 0.28185f;
    }


    private float EvaluateSparksSpeed(float laserDistance)
    {
        return 0.14515f * laserDistance + 1.2742f;
    }


    private float EvaluateFlameLifeTime(float laserDistance)
    {
        return 0.01814f * laserDistance + 0.10927f;
    }


    private Vector3 EvaluateFlamePosition(float laserDistance)
    {
        return new Vector2(_sourceFlame.transform.localPosition.x, -0.03284f * laserDistance + 0.08452f);
    }
}