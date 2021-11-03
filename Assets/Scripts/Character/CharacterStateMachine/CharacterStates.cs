

public class CharacterStates
{
    public readonly IdleState IdleState;
    public readonly FallState FallState;
    public readonly RunState RunState;
    public readonly DieState DieState;
    

    public CharacterStates(Character character)
    {
        IdleState = new IdleState(character);
        FallState = new FallState(character);
        RunState = new RunState(character);
        DieState = new DieState(character);
    }
}
 
