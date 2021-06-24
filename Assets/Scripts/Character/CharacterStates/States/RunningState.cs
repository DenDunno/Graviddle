using UnityEngine;


public class RunningState : CharacterState
{
    private readonly Transform _characterTransform;
    private readonly CharacterMovement _movement;


    public RunningState(Character character) : base(character)
    {
        _movement = character.GetComponent<CharacterMovement>();
        _characterTransform = character.transform;
    }


    public override void EnterState()
    {
        _animator.Play("Run");
    }


    public override CharacterState Update()
    {
        int sign = (int)_movement.СharacterMovement;

        if (sign == 0)
        {
            return CharacterStates.IdleState;
        }

        var direction = _characterTransform.position + Vector3.right * sign;
        _characterTransform.position = Vector3.MoveTowards(_characterTransform.position, direction, 2 * Time.deltaTime);

        return this;
    }
}
