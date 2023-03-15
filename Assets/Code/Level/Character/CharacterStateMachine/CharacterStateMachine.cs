
public class CharacterStateMachine : IFixedUpdate, IUpdate
{
    private readonly TransitionsPresenter _transitionsPresenter;
    private CharacterState _state;

    public CharacterStateMachine(TransitionsPresenter transitionsPresenter, CharacterState initialState)
    {
        _transitionsPresenter = transitionsPresenter;
        _state = initialState;
    }

    void IFixedUpdate.FixedUpdate()
    {
        _state.FixedUpdate();
    }

    void IUpdate.Update()
    {
        _state.Update();
        TryTransit();
    }

    private void TryTransit()
    {
        CharacterState newState = _transitionsPresenter.Transit(_state);
        
        if (newState != _state)
        {
            SwitchState(newState);
        }
    }

    private void SwitchState(CharacterState newState)
    {
        _state.Exit();
        _state = newState;
        _state.Enter();
    }
}