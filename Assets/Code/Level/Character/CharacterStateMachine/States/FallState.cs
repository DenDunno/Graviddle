using System;
using UnityEngine;

public class FallState : CharacterState
{    
    public FallState(Animator character) : base(character, AnimationsName.Fall)
    {
    }
}