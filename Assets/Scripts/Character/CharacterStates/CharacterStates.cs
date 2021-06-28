using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterStates : MonoBehaviour
{
    public static IdleState IdleState { get; private set; }
    public static RunningState RunningState { get; private set; }
    public static FallState FallState { get; private set; }
    public static DieState DieState { get; private set; }


    public void Init()
    {
        var character = GetComponent<Character>();

        IdleState = new IdleState(character);
        RunningState = new RunningState(character);
        FallState = new FallState(character);
        DieState = new DieState(character);
    }
}

