using UnityEngine;


public class CharacterStates : MonoBehaviour
{
    public static IdleState IdleState { get; private set; }
    public static RunningState RunningState { get; private set; }
    public static FallState FallState { get; private set; }
    public static DieState DieState { get; private set; }

    [SerializeField] private Character _character;
    [SerializeField] private SwipeHandler _swipeHandler;


    private void Start()
    {
        IdleState = new IdleState(_character, _swipeHandler);
        RunningState = new RunningState(_character);
        FallState = new FallState(_character);
        DieState = new DieState(_character);
    }
}

