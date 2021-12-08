using System;


public class FallState : CharacterState
{
    public event Action CharacterFalling;


    public FallState(Character character) : base(character , AnimationsName.Fall)
    {
    }


    protected override void OnEnterState()
    {
        CharacterFalling?.Invoke();
    }
}