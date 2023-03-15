using System;
using UnityEngine;

public class Character : MonoBehaviourWrapper
{
    [SerializeField] private CharacterFootstepsSound _footstepsSound;
    [SerializeField] private ConstantForce2D _constantForce2d;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TrailRenderer _trailRenderer;
    [SerializeField] private ParticleSystem _fallingDust;
    [SerializeField] private CollisionsList _collisions;
    [SerializeField] private AnimationCurve _fadeCurve;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    public event Action Respawned;
    
    public void Init(CharacterData data)
    {
        CharacterStatesPresenter states = data.States;
        Transition fallToIdleTransition = data.TransitionsPresenter.GetTransition(states.FallState, states.IdleState);
        Gravity gravity = new(_constantForce2d, 15, GravityDirection.Down);
        GravityRotation gravityRotation = new(data.GravityState, transform);

        SetDependencies(new IUnityCallback[]
        {
            gravity,
            _footstepsSound,
            gravityRotation,
            data.GravityState,
            data.MovementDirection,
            new CharacterGravity(gravity, data.SwipeHandler),
            new CharacterRotationImpulse(_rigidbody2D, data.SwipeHandler),
            new CharacterStateMachine(data.TransitionsPresenter, states.IdleState),
            new SwipeHandlerSwitcher(data.SwipeHandler, fallToIdleTransition, states.FallState),
            new CharacterToPortalPulling(states.WinState, transform, _collisions, gravityRotation),
            new CharacterVFX(_fallingDust, _trailRenderer, fallToIdleTransition, states.FallState),
            new TwistingAnimationHandler(_spriteRenderer, states.WinState, _fadeCurve, InvokeRespawnEvent),
            new SquashStretchAnimation(_rigidbody2D, _spriteRenderer, fallToIdleTransition, states.FallState),
        });
    }

    private void InvokeRespawnEvent()
    {
        Respawned?.Invoke();
    }
}