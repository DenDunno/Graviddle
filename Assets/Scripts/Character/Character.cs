using UnityEngine;


public class Character : MonoBehaviour, IMediator, IRestartableTransform
{
    [LightweightInject] private readonly CharacterStatesPresenter _states;
    [LightweightInject] private readonly LevelRestart _levelRestart;
    [SerializeField] private SwipeHandler _swipeHandler;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private CharacterRestart _characterRestart;
    private CharacterRotationImpulse _characterRotationImpulse;
    private CharacterTransparency _characterTransparency;
    
    
    void IMediator.Resolve()
    {
        _characterTransparency = new CharacterTransparency(_spriteRenderer);
        _characterRotationImpulse = new CharacterRotationImpulse(_rigidbody2D);

        _characterTransparency.Init();
        _characterRestart.Init(new []{_characterTransparency}, new []{_characterTransparency});
    }


    private void OnEnable()
    {
        _swipeHandler.GravityChanged += _characterRotationImpulse.TryImpulseCharacter;
        _states.DieState.CharacterDied += _levelRestart.MakeRestart;
        _states.WinState.CharacterWon += _characterTransparency.BecomeTransparentWithDelay;
    }


    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= _characterRotationImpulse.TryImpulseCharacter;
        _states.DieState.CharacterDied -= _levelRestart.MakeRestart;
        _states.WinState.CharacterWon -= _characterTransparency.BecomeTransparentWithDelay;
    }
}