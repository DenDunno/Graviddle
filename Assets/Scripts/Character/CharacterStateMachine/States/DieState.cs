using System;


public class DieState : CharacterState
{
    public event Action CharacterDied;


    public DieState(Character character) : base(character)
    {
    }


    public override void EnterState()
    {
        CharacterDied?.Invoke();
        _animator.Play(CharacterAnimations.Die);
    }


    public override CharacterState Update()
    {
        return this;
    }
}
