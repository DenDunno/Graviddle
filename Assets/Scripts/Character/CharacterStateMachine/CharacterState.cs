using UnityEngine;


public abstract class CharacterState
{
    protected readonly Animator _animator;


    protected CharacterState(Character character)
    {
        _animator = character.GetComponent<Animator>();
    }


    public abstract void EnterState();
    public abstract CharacterState Update();
}

