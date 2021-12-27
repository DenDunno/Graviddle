using UnityEngine;


public class CharacterVFX : CharacterFallingEventsHandler
{
    [SerializeField] private ParticleSystem _dust = null;
    [SerializeField] private TrailRenderer _trailRenderer = null;


    protected override void OnCharacterStartFalling()
    {
        _trailRenderer.emitting = true;
    }


    protected override void OnCharacterEndFalling()
    {
        _dust.Play();
        _trailRenderer.emitting = false;
    }
}