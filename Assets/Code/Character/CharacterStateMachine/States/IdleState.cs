using UnityEngine;


public class IdleState : CharacterState
{
    public IdleState(Animator character) : base(character, AnimationsName.Idle)
    {
    }
}