

public class DieState : CharacterState
{
    public DieState(Character character) : base(character)
    {
    }


    public override void EnterState()
    {
        _animator.Play("Die");
    }


    public override CharacterState Update()
    {
        return this;
    }
}
