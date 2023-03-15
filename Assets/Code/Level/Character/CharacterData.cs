using System;
using UnityEngine;

[Serializable]
public class CharacterData
{
    [SerializeField] private TransitionsConditions _transitionsConditions;
    [SerializeField] private CharacterMovementDirection _characterMovementDirection;    
    [SerializeField] private SwipeHandler _swipeHandler;

    public CharacterStatesPresenter States { get; private set; }
    public CharacterGravityState GravityState { get; private set; }
    public TransitionsPresenter TransitionsPresenter { get; private set; }
    public SwipeHandler SwipeHandler => _swipeHandler;
    public CharacterMovementDirection MovementDirection => _characterMovementDirection;

    public void Init(Character character, LevelBorders borders, Func<bool> restartCondition)
    {
        States = new CharacterStatesPresenter(character.GetComponent<Animator>(), _characterMovementDirection);
        TransitionsPresenter = new TransitionsPresenterFactory(States, _transitionsConditions).Create();
        GravityState = new CharacterGravityState(_swipeHandler);

        _characterMovementDirection.Init(GravityState);
        _transitionsConditions.Init(_characterMovementDirection, character.transform, borders, restartCondition);
    }
}