using System;
using UnityEngine;


[Serializable]
public class CharacterStatesTransitionsFactory
{
    [SerializeField] private EventTransitionsPresenterFactory _eventTransitionsPresenterFactory = null;
    [SerializeField] private UpdateTransitionsPresenterFactory _updateTransitionsPresenterFactory = null;


    public void Init(Character character, CharacterStatesPresenter states)
    {
        _eventTransitionsPresenterFactory.Init(states);
        _updateTransitionsPresenterFactory.Init(character, states);
    }


    public CharacterStateTransitions Create()
    {
        TransitionPresenter eventTransitionsPresenter = _eventTransitionsPresenterFactory.Create();
        TransitionPresenter updateTransitionsPresenter = _updateTransitionsPresenterFactory.Create();

        return new CharacterStateTransitions(eventTransitionsPresenter, updateTransitionsPresenter);
    }
}