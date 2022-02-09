using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour, IMediator
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
        var dependencies = new List<object>();
        dependencies.Add(_characterTransparency = new CharacterTransparency(_spriteRenderer));
        dependencies.Add(_characterRotationImpulse = new CharacterRotationImpulse(_rigidbody2D));
        _characterRestart.Init(dependencies);
    }


    private void OnEnable()
    {
        _swipeHandler.GravityChanged += _characterRotationImpulse.TryImpulseCharacter;
        _states.DieState.CharacterDied += _levelRestart.MakeRestart;
    }


    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= _characterRotationImpulse.TryImpulseCharacter;
        _states.DieState.CharacterDied -= _levelRestart.MakeRestart;
    }
}