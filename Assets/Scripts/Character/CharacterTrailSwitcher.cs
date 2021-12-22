using UnityEngine;


public class CharacterTrailSwitcher : CharacterFallingEventsHandler
{
    [SerializeField] private TrailRenderer _trailRenderer = null;


    protected override void OnCharacterFalling()
    {
        _trailRenderer.emitting = true;
    }


    protected override void OnCharacterGrounded()
    {
        _trailRenderer.emitting = false;
    }
}