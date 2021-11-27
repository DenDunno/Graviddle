
public abstract class MovableState : CharacterState
{
    private readonly CharacterMovement _characterMovement;


    protected MovableState(Character character, string animationName) : base(character, animationName)
    {
        _characterMovement = new CharacterMovement(character);
    }

    public override void Update()
    {
        _characterMovement.Update();
    }
}
