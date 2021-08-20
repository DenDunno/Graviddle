

public static class CharacterStates 
{ 
    public static IdleState IdleState { get; private set; }
    public static FallState FallState { get; private set; }
    public static RunState RunState { get; private set; }
    public static DieState DieState { get; private set; }
    

    public static void Init(Character character)
    {
        IdleState = new IdleState(character);
        FallState = new FallState(character);
        RunState = new RunState(character);
        DieState = new DieState(character);
    }
}
 
