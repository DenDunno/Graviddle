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
        _updateTransitionsPresenterFactory.Init(character, states);
    }


    public CharacterStateTransitions Create()
    {
        TransitionsPresenter eventTransitionsPresenter = _eventTransitionsPresenterFactory.Create();
        TransitionsPresenter updateTransitionsPresenter = _updateTransitionsPresenterFactory.Create();

        return new CharacterStateTransitions(eventTransitionsPresenter, updateTransitionsPresenter);
    }
}