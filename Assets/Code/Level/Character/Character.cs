using UnityEngine;

public class Character : MonoBehaviourWrapper
{
    [SerializeField] private ConstantForce2D _constantForce2d;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private ParticleSystem _fallingDust;
    [SerializeField] private TrailRenderer _trailRenderer;
    [SerializeField] private AnimationCurve _fadeCurve;
    [SerializeField] private CollisionsList _collisions;
    
    public void Init(TransitionsPresenter transitionsPresenter, CharacterStatesPresenter states, SwipeHandler swipeHandler, GravityState gravityState)
    {
        Transition fallToIdleTransition = transitionsPresenter.GetTransition(states.FallState, states.IdleState);
        Gravity gravity = new(_constantForce2d, 15);
        GravityRotation gravityRotation = new(gravityState, transform);
        
        SetDependencies(new IUnityCallback[]
        {
            gravity,
            gravityState,
            gravityRotation,
            new CharacterPhysicsRestart(_rigidbody2D),
            new CharacterGravity(gravity, swipeHandler),
            new CharacterRotationImpulse(_rigidbody2D, swipeHandler),
            new CharacterStateMachine(transitionsPresenter, states.IdleState),
            new TwistingAnimation(_spriteRenderer, states.WinState, _fadeCurve),
            new SwipeHandlerSwitcher(swipeHandler, fallToIdleTransition, states.FallState),
            new CharacterToPortalPulling(states.WinState, transform, _collisions, gravityRotation),
            new CharacterVFX(_fallingDust, _trailRenderer, fallToIdleTransition, states.FallState),
            new SquashStretchAnimation(_rigidbody2D, _spriteRenderer, fallToIdleTransition, states.FallState),
        });
    }
}