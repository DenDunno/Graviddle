using System;
using UnityEngine;


public class FallState : CharacterState
{
    public event Action CharacterFalling;


    public FallState(Animator character) : base(character, AnimationsName.Fall)
    {
    }

    
    protected override void OnEnterState()
    {
        CharacterFalling?.Invoke();
    }
}