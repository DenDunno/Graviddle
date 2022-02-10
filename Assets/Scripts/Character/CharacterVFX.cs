using System;
using UnityEngine;


[Serializable]
public class CharacterVFX : CharacterFallingEventsHandler
{
    [SerializeField] private ParticleSystem _fallingDust;
    [SerializeField] private TrailRenderer _trailRenderer;
    

    public override void OnCharacterStartFalling()
    {
        _trailRenderer.emitting = true;
    }


    public override void OnCharacterEndFalling()
    {
        _fallingDust.Play();
        _trailRenderer.emitting = false;
    }
}