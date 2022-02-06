using UnityEngine;


public class CharacterVFX : CharacterFallingEventsHandler, IRestartableComponent
{
    [SerializeField] private ParticleSystem _fallingDust;
    [SerializeField] private TrailRenderer _trailRenderer;


    protected override void OnCharacterStartFalling()
    {
        _trailRenderer.emitting = true;
    }


    protected override void OnCharacterEndFalling()
    {
        _fallingDust.Play();
        _trailRenderer.emitting = false;
    }


    void IRestartableComponent.Restart()
    {
        OnCharacterEndFalling();
    }
}