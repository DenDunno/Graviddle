using System;


public class DieState : CharacterState
{
    public event Action CharacterDied;
    private readonly CharacterStateMachine _characterStateMachine;


    public DieState(Character character) : base(character , AnimatorCharacterController.States.Die)
    {
        _characterStateMachine = character.GetComponent<CharacterStateMachine>();
    }


    public override void EnterState()
    {
        base.EnterState();

        _characterStateMachine.enabled = false;
        CharacterDied?.Invoke();
    }


    public override CharacterState Update()
    {
        return this;
    }
}
