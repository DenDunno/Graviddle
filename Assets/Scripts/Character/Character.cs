using UnityEngine;


public class Character : MonoBehaviour, IRestartableTransform
{
    [SerializeField] private SwipeHandler _swipeHandler;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private CharacterRestart _characterRestart;
    [SerializeField] private CharacterVFX _characterVFX;
    [SerializeField] private SwipeHandlerSwitcher _swipeHandlerSwitcher;
    private CharacterFallingEventsHandler[] _fallingEventsHandlers;
    private CharacterRotationImpulse _characterRotationImpulse;
    private CharacterTransparency _characterTransparency;
    private CharacterStatesPresenter _states;
    private Transition _fallToIdleTransition;
    private LevelRestart _levelRestart;


    public void Init(LevelRestart levelRestart, Transition fallToIdleTransition, CharacterStatesPresenter states)
    {
        _states = states;
        _levelRestart = levelRestart;
        _fallToIdleTransition = fallToIdleTransition;
        _characterTransparency = new CharacterTransparency(_spriteRenderer);
        _characterRotationImpulse = new CharacterRotationImpulse(_rigidbody2D);
        _fallingEventsHandlers = new CharacterFallingEventsHandler[] {_characterVFX, _swipeHandlerSwitcher};
        
        _characterTransparency.Init();
        _characterRestart.Init(new []{_characterTransparency}, new []{_characterTransparency});
    }


    private void OnEnable()
    {
        _swipeHandler.GravityChanged += _characterRotationImpulse.TryImpulseCharacter;
        _states.DieState.CharacterDied += _levelRestart.MakeRestart;
        _states.WinState.CharacterWon += _characterTransparency.BecomeTransparentWithDelay;
        
        foreach (CharacterFallingEventsHandler characterFallingEventsHandler in _fallingEventsHandlers)
        {
            _states.FallState.CharacterFalling += characterFallingEventsHandler.OnCharacterStartFalling;
            _fallToIdleTransition.TransitionHappened += characterFallingEventsHandler.OnCharacterEndFalling;
        }
    }


    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= _characterRotationImpulse.TryImpulseCharacter;
        _states.DieState.CharacterDied -= _levelRestart.MakeRestart;
        _states.WinState.CharacterWon -= _characterTransparency.BecomeTransparentWithDelay;
        
        foreach (CharacterFallingEventsHandler characterFallingEventsHandler in _fallingEventsHandlers)
        {
            _states.FallState.CharacterFalling -= characterFallingEventsHandler.OnCharacterStartFalling;
            _fallToIdleTransition.TransitionHappened -= characterFallingEventsHandler.OnCharacterEndFalling;
        }
    }
}