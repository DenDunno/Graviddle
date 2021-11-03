using UnityEngine;


public abstract class CharacterState
{
    private readonly Animator _animator;
    private readonly string _animationName;
    private readonly StateTransitions _stateTransitions;


    protected CharacterState(Character character , string animationName , StateTransitions stateTransitions)
    {
        _animator = character.GetComponent<Animator>();
        _animationName = animationName;
        _stateTransitions = stateTransitions;
    }
    

    public void Enter()
    {
        _animator.Play(_animationName);

        OnEnterState();
    }

    public CharacterState Update()
    {
        OnUpdateState();

        return _stateTransitions.TryGetNewState();
    }

    protected virtual void OnEnterState() { }
    protected virtual void OnUpdateState() { }
}