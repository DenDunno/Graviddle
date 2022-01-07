using UnityEngine;
using Zenject;


public class CharacterStateMachine : MonoBehaviour, IRestartableComponent
{
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;
    [Inject] private readonly CharacterStateTransitions _characterStateTransitions = null;
    public CharacterState State { get; private set; }


    private void Start()
    {
        State = _characterStatesPresenter.IdleState;
        _characterStateTransitions.Init(this);
    }
    

    private void SwitchState(CharacterState newState)
    {
        State = newState;
        State.Enter();
    }


    private void Update()
    {
        State.Update();
        TryTransit();
    }


    private void TryTransit()
    {
        TransitionResult transitionResult = _characterStateTransitions.Transit(State);

        if (transitionResult.TransitionHappened)
        {
            SwitchState(transitionResult.NewState);
        }
    }


    void IRestartableComponent.Restart()
    {
        SwitchState(_characterStatesPresenter.IdleState);
    }
}