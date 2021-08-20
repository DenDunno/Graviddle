using System;


public class DieState : CharacterState
{
    public event Action CharacterDied;


    public DieState(Character character) : base(character , AnimatorCharacterController.States.Die)
    {
    }


    public override void EnterState()
    {
        base.EnterState();
        CharacterDied?.Invoke();
    }


    public override CharacterState Update()
    {
        return this;
    }
}
