using UnityEngine;

public class Character : MonoBehaviourWrapper
{
    [SerializeField] private SwipeHandler _swipeHandler;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private ParticleSystem _fallingDust;
    [SerializeField] private TrailRenderer _trailRenderer;
    [SerializeField] private AnimationCurve _fadeCurve;
    
    public void Init(TransitionsPresenter transitionsPresenter, CharacterStatesPresenter states)
    {
        Transition fallToIdleTransition = transitionsPresenter.GetTransition(states.FallState, states.IdleState);

        SetDependencies(new IUnityCallback[]
        {
            new CharacterStateMachine(transitionsPresenter, states.IdleState),
            new CharacterPhysicsRestart(_rigidbody2D),
            new TwistingAnimation(_spriteRenderer, states.WinState, _fadeCurve),
            new CharacterRotationImpulse(_rigidbody2D, _swipeHandler),
            new SwipeHandlerSwitcher(_swipeHandler, fallToIdleTransition, states.FallState),
            new CharacterVFX(_fallingDust, _trailRenderer, fallToIdleTransition, states.FallState),
            new SquashStretchAnimation(_rigidbody2D, _spriteRenderer, fallToIdleTransition, states.FallState)
        });
    }
}