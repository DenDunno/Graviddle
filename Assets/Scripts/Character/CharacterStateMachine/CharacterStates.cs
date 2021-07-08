using System;
using UnityEngine;


[Serializable]
public class CharacterStates 
{ 
    public static IdleState IdleState { get; private set; }
    public static FallState FallState { get; private set; }
    public static RunState RunState { get; private set; }
    public static DieState DieState { get; private set; }

    [SerializeField] private SwipeHandler _swipeHandler = null;
    

    public void Init(Character character , Action characterDeathCallback)
    {
        IdleState = new IdleState(character);
        FallState = new FallState(character, _swipeHandler);
        RunState = new RunState(character);
        DieState = new DieState(character , characterDeathCallback);
    }
}

