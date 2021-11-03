using System;


public class DieState : CharacterState
{
    public event Action CharacterDied;


    public DieState(Character character) : base(character , AnimationsName.Die)
    {
    }


    protected override void OnEnterState()
    {
        CharacterDied?.Invoke();
    }
}
