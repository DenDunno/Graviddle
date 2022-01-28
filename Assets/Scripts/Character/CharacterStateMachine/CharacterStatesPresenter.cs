using System.Collections.Generic;
using System.Collections.ObjectModel;


public class CharacterStatesPresenter
{
    public readonly FallState FallState;
    public readonly DieState DieState;
    public readonly WinState WinState;
    public readonly IdleState IdleState;
    public readonly IdleState BoxIdle;
    public readonly MovableState BoxPushingState;
    public readonly MovableState BoxPullingState;
    public readonly MovableState RunState;
    public readonly ReadOnlyCollection<CharacterState> GameActiveStates;
    

    public CharacterStatesPresenter(Character character)
    {
        FallState = new FallState(character);
        DieState = new DieState(character);
        WinState = new WinState(character);
        IdleState = new IdleState(character, AnimationsName.Idle);
        BoxIdle = new IdleState(character, AnimationsName.Idle);
        BoxPushingState = new MovableState(character, 1.5f, AnimationsName.Idle);
        BoxPullingState = new MovableState(character, 1.5f, AnimationsName.Fall);
        RunState = new MovableState(character, 3, AnimationsName.Run);

        GameActiveStates = new List<CharacterState>
        {
            FallState, IdleState, RunState,
            BoxIdle, BoxPushingState, BoxPullingState
        }.AsReadOnly();
    }
}
 
