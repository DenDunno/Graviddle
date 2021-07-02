using UnityEngine;
using UnityEngine.Events;


public class DieState : CharacterState
{
    private readonly UnityEvent _characterDeathEvent;


    public DieState(Character character, UnityEvent characterDeathEvent) : base(character)
    {
        _characterDeathEvent = characterDeathEvent;
    }


    public override void EnterState()
    {
        _characterDeathEvent?.Invoke();
        _animator.Play("Die");
    }


    public override CharacterState Update()
    {
        return this;
    }
}
