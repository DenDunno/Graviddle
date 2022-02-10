using UnityEngine;


public class Character : MonoBehaviour, IMediator, IRestartableTransform
{
    [SerializeField] private SwipeHandler _swipeHandler;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private CharacterRestart _characterRestart;
    private ICharacterFallingEventsHandler[] _fallingEventsHandlers;
    private CharacterRotationImpulse _characterRotationImpulse;
    private CharacterTransparency _characterTransparency;
    private CharacterStatesPresenter _states;
    private Transition _fallToIdleTransition;
    private LevelRestart _levelRestart;


    public void Init(LevelRestart levelRestart, TransitionsPresenter transitionsPresenter, CharacterStatesPresenter states)
    {
        _states = states;
        _levelRestart = levelRestart;
        _fallToIdleTransition = transitionsPresenter.GetTransition(_states.FallState, _states.IdleState);
    }
    
    
    void IMediator.Resolve()
    {
        _characterTransparency = new CharacterTransparency(_spriteRenderer);
        _characterRotationImpulse = new CharacterRotationImpulse(_rigidbody2D);
        _fallingEventsHandlers = new ICharacterFallingEventsHandler[] {new SwipeHandlerSwitcher(_swipeHandler)};
        
        _characterTransparency.Init();
        _characterRestart.Init(new []{_characterTransparency}, new []{_characterTransparency});
    }


    private void OnEnable()
    {
        _swipeHandler.GravityChanged += _characterRotationImpulse.TryImpulseCharacter;
        _states.DieState.CharacterDied += _levelRestart.MakeRestart;
        _states.WinState.CharacterWon += _characterTransparency.BecomeTransparentWithDelay;
        _fallingEventsHandlers.ForEach(fallingEventsHandler => _states.FallState.CharacterFalling += fallingEventsHandler.OnCharacterStartFalling);
    }


    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= _characterRotationImpulse.TryImpulseCharacter;
        _states.DieState.CharacterDied -= _levelRestart.MakeRestart;
        _states.WinState.CharacterWon -= _characterTransparency.BecomeTransparentWithDelay;
        _fallingEventsHandlers.ForEach(fallingEventsHandler => _fallToIdleTransition.TransitionHappened += fallingEventsHandler.OnCharacterEndFalling);
    }
}