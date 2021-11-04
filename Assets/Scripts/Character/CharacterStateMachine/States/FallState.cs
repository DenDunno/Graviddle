using System;


public class FallState : MovableState
{
    public event Action<bool> CharacterGroundedChanged;


    public FallState(Character character) : base(character , AnimationsName.Fall)
    {
    }


    protected override void OnEnterState()
    {
        CharacterGroundedChanged?.Invoke(false);
    }
}