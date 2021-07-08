using System;


public class DieState : CharacterState
{
    private readonly Action _characterDeathCallback;


    public DieState(Character character , Action characterDeathCallback) : base(character)
    {
        _characterDeathCallback = characterDeathCallback;
    }


    public override void EnterState()
    {
        _characterDeathCallback();
        _animator.Play("Die");
    }


    public override CharacterState Update()
    {
        return this;
    }
}
