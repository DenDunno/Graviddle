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


    public void Init(Transition fallToIdleTransition, CharacterStatesPresenter states, CharacterRestartEvent restartEvent, LevelRestart levelRestart)
    {
        object[] dependencies = 
        {
            restartEvent,
            levelRestart,
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
        _subscribers.ForEach(subscriber => subscriber.Subscribe());
    }


    private void OnDisable()
    {
        _subscribers.ForEach(subscriber => subscriber.Unsubscribe());
    }

    
    void IRestart.Restart()
    {
        _restartComponents.ForEach(restartComponent => restartComponent.Restart());
    }
    
    
    void IAfterRestart.Restart()
    {
        _afterRestartComponents.ForEach(restartComponent => restartComponent.Restart());
    }
}