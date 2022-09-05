using UnityEngine;


public class Character : MonoBehaviourWrapper
{
    [SerializeField] private SwipeHandler _swipeHandler;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private ParticleSystem _fallingDust;
    [SerializeField] private TrailRenderer _trailRenderer;
    
    
    public void Init(TransitionsPresenter transitionsPresenter, CharacterStatesPresenter states)
    {
        Transition fallToIdleTransition = transitionsPresenter.GetTransition(states.FallState, states.IdleState);

        SetDependencies(new object[]
        {
            new CharacterStateMachine(transitionsPresenter, states.IdleState),
            new CharacterPhysicsRestart(_rigidbody2D),
            new CharacterTransparency(_spriteRenderer, states.WinState),
            new CharacterRotationImpulse(_rigidbody2D, _swipeHandler),
            new SwipeHandlerSwitcher(_swipeHandler, fallToIdleTransition, states.FallState),
            new CharacterVFX(_fallingDust, _trailRenderer, fallToIdleTransition, states.FallState),
            new SquashStretchAnimation(_rigidbody2D, _spriteRenderer, fallToIdleTransition, states.FallState)
        });
    }
}