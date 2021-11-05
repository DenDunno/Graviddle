using System;


public class IdleState : CharacterState
{
    public event Action CharacterGrounded;


    public IdleState(Character character) : base(character , AnimationsName.Idle)
    {
    }


    protected override void OnEnterState()
    {
        CharacterGrounded?.Invoke();
    }
}