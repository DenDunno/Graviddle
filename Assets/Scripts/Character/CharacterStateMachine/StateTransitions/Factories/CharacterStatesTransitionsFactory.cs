using System;
using UnityEngine;


[Serializable]
public class CharacterStatesTransitionsFactory
{
    [SerializeField] private EventTransitionsPresenterFactory _eventTransitionsPresenterFactory;
    [SerializeField] private UpdateTransitionsPresenterFactory _updateTransitionsPresenterFactory;


    public void Init(Character character, CharacterStatesPresenter states)
    {
        _eventTransitionsPresenterFactory.SetStates(states);
        _updateTransitionsPresenterFactory.SetStates(states);
        _updateTransitionsPresenterFactory.CreateConditions(character);
    }


    public CharacterStateTransitions Create()
    {
        TransitionPresenter eventTransitionsPresenter = _eventTransitionsPresenterFactory.Create();
        TransitionPresenter updateTransitionsPresenter = _updateTransitionsPresenterFactory.Create();

        return new CharacterStateTransitions(eventTransitionsPresenter, updateTransitionsPresenter);
    }
}