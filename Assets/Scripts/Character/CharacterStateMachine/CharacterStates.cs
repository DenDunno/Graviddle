using UnityEngine;


public class CharacterStates 
{ 
    public static IdleState IdleState { get; private set; }
    public static FallState FallState { get; private set; }
    public static RunState RunState { get; private set; }
    public static DieState DieState { get; private set; }


    public static void Init()
    {
        var character = Object.FindObjectOfType<Character>();
        var swipeHandler = Object.FindObjectOfType<SwipeHandler>();

        FallState = new FallState(character, swipeHandler);
        IdleState = new IdleState(character);
        RunState = new RunState(character);
        DieState = new DieState(character);
    }
}

