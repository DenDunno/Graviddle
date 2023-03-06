using DG.Tweening;
using UnityEngine;

public class CharacterToPortalPulling : ISubscriber
{
    private readonly float _animationDuration = 1.25f;
    private readonly GravityRotation _gravityRotation;
    private readonly CollisionsList _collisions;
    private readonly Transform _character;
    private readonly WinState _winState;

    public CharacterToPortalPulling(WinState winState, Transform character, CollisionsList collisions)
    {
        _winState = winState;
        _character = character;
        _collisions = collisions;
        _gravityRotation = character.GetComponent<GravityRotation>();
    }

    public void Subscribe()
    {
        _winState.Entered += PullToPortal;
    }

    public void Unsubscribe()
    {
        _winState.Entered -= PullToPortal;
    }

    private void PullToPortal()
    {
        _gravityRotation.enabled = false;

        FinishPortal finishPortal = _collisions.GetComponentFromList<FinishPortal>();
        
        _character.DOMove(finishPortal.PullingPoint.position, _animationDuration);
        _character.DORotate(finishPortal.PullingPoint.eulerAngles, _animationDuration);
    }
}