using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Character : MonoBehaviour, IRestartableTransform, IRestart, IAfterRestart
{
    [SerializeField] private SwipeHandler _swipeHandler;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private ParticleSystem _fallingDust;
    [SerializeField] private TrailRenderer _trailRenderer;
    private IEnumerable<IAfterRestart> _afterRestartComponents;
    private IEnumerable<IRestart> _restartComponents;
    private IEnumerable<ISubscriber> _subscribers;


    public void Init(Transition fallToIdleTransition, CharacterStatesPresenter states, CharacterRestartEvent restartEvent)
    {
        object[] dependencies = 
        {
            restartEvent,
            new CharacterPhysicsRestart(_rigidbody2D),
            new CharacterTransparency(_spriteRenderer, states.WinState),
            new CharacterRotationImpulse(_rigidbody2D, _swipeHandler),
            new SwipeHandlerSwitcher(_swipeHandler, fallToIdleTransition, states.FallState),
            new CharacterVFX(_fallingDust, _trailRenderer, fallToIdleTransition, states.FallState)
        };

        dependencies.OfType<IInitializable>().ForEach(initializable => initializable.Init());
        _afterRestartComponents = dependencies.OfType<IAfterRestart>();
        _restartComponents = dependencies.OfType<IRestart>();
        _subscribers = dependencies.OfType<ISubscriber>();
    }


    private void OnEnable()
    {
        _subscribers.SubscribeForEach();
    }


    private void OnDisable()
    {
        _subscribers.UnsubscribeForEach();
    }

    
    void IRestart.Restart()
    {
        _restartComponents.RestartForEach();
    }
    
    
    void IAfterRestart.Restart()
    {
        _afterRestartComponents.RestartForEach();
    }
}