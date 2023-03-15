using DG.Tweening;
using UnityEngine;

public class CharacterToPortalPulling : ISubscriber
{
    private readonly float _animationDuration = 1.25f;
    private readonly GravityRotation _gravityRotation;
    private readonly CollisionsList _collisions;
    private readonly Transform _character;
    private readonly WinState _winState;

    public CharacterToPortalPulling(WinState winState, Transform character, CollisionsList collisions, GravityRotation gravityRotation)
    {
        _winState = winState;
        _character = character;
        _collisions = collisions;
        _gravityRotation = gravityRotation;
    }

    void ISubscriber.Subscribe()
    {
        _winState.Entered += PullToPortal;
    }

    void ISubscriber.Unsubscribe()
    {
        _winState.Entered -= PullToPortal;
    }

    private void PullToPortal()
    {
        _gravityRotation.IsActive = false;

        FinishPortal finishPortal = _collisions.GetComponentFromList<FinishPortal>();
        
        _character.DOMove(finishPortal.PullingPoint.position, _animationDuration);
        _character.DORotate(finishPortal.PullingPoint.eulerAngles, _animationDuration);
    }
}