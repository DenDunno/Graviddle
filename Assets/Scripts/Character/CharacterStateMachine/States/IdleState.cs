using UnityEngine;


public class IdleState : CharacterState
{
    private readonly CharacterMovement _characterMovement;


    public IdleState(Character character) : base(character , AnimatorCharacterController.States.Idle)
    {
        _characterMovement = character.GetComponent<CharacterMovement>();
    }
    

    public override CharacterState Update()
    {
        if (_characterMovement.MoveDirection != Vector2.zero)
        {
            return CharacterStates.RunState;
        }

        return this;
    }
}