using UnityEngine;


public abstract class CharacterState
{
    private readonly Animator _animator;
    private readonly string _animationStateName;


    protected CharacterState(Character character , string animationStateName)
    {
        _animator = character.GetComponent<Animator>();
        _animationStateName = animationStateName;
    }
    

    public virtual void EnterState()
    {
        _animator.Play(_animationStateName);
    }

    public abstract CharacterState Update();
}

