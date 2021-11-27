using UnityEngine;


public class CharacterStateMachine : MonoBehaviour, IRestartableComponent
{
    private TransitionsPresenter _transitionsPresenter;
    private TransitionEventsPresenter _transitionEventsPresenter;
    private CharacterState _state;
    private CharacterState _initialState;


    public void Init(CharacterState initialState, TransitionsPresenter transitions, TransitionEventsPresenter events)
    {
        _initialState = initialState;
        _state = initialState;
        _transitionsPresenter = transitions;
        _transitionEventsPresenter = events;
    }
    

    private void SwitchState(CharacterState newState)
    {
        _state = newState;
        _state.Enter();
    }


    private void Update()
    {
        _state.Update();

        if (_transitionsPresenter.TryTransit(_state, out CharacterState newState))
        {
            _transitionEventsPresenter.TryInvokeTransitionEvent(_state, newState);
            SwitchState(newState);
        }
    }


    void IRestartableComponent.Restart()
    {
        SwitchState(_initialState);
    }
}