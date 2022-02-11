using UnityEngine;


public class CharacterVFX : CharacterFallingEventsHandler
{
    private readonly ParticleSystem _fallingDust;
    private readonly TrailRenderer _trailRenderer;

    
    public CharacterVFX(ParticleSystem fallingDust, TrailRenderer trailRenderer, Transition fallToIdleTransition, FallState fallState) 
        : base(fallToIdleTransition, fallState)
    {
        _fallingDust = fallingDust;
        _trailRenderer = trailRenderer;
    }


    protected override void OnCharacterStartFalling()
    {
        _trailRenderer.emitting = true;
    }


    protected override void OnCharacterEndFalling()
    {
        _fallingDust.Play();
        _trailRenderer.emitting = false;
    }
}