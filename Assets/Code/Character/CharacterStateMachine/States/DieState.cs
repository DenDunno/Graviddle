using System;
using UnityEngine;

public class DieState : CharacterState
{
    public event Action CharacterDied;

    public DieState(Animator character) : base(character, AnimationsName.Die)
    {
    }

    protected override void OnEnterState()
    {
        CharacterDied?.Invoke();
    }
}
