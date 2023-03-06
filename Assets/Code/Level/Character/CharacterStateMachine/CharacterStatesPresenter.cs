using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class CharacterStatesPresenter
{
    public readonly FallState FallState;
    public readonly DieState DieState;
    public readonly WinState WinState;
    public readonly IdleState IdleState;
    public readonly RunState RunState;
    public readonly ReadOnlyCollection<CharacterState> GameActiveStates;

    public CharacterStatesPresenter(Animator character, CharacterMovementDirection characterMovementDirection)
    {
        FallState = new FallState(character);
        DieState = new DieState(character);
        WinState = new WinState(character);
        IdleState = new IdleState(character);
        RunState = new RunState(character, characterMovementDirection);

        GameActiveStates = new List<CharacterState>
        {
            FallState, IdleState, RunState
        }.AsReadOnly();
    }
}
 
