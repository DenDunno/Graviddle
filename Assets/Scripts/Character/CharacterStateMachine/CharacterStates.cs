using UnityEngine;


public class CharacterStates 
{ 
    public static IdleState IdleState { get; private set; }
    public static FallState FallState { get; private set; }
    public static RunState RunState { get; private set; }
    public static DieState DieState { get; private set; }


    static CharacterStates()
    {
        var character = Object.FindObjectOfType<Character>();

        IdleState = new IdleState(character);
        FallState = new FallState(character);
        RunState = new RunState(character);
        DieState = new DieState(character);
    }
}

