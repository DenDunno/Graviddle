using System;
using UnityEngine;

public abstract class CharacterState
{
    private readonly Animator _animator;
    private readonly string _animationName;

    protected CharacterState(Animator animator, string animationName)
    {
        _animator = animator;
        _animationName = animationName;
    }

    public event Action Entered;
    public event Action Exited;

    public void Enter()
    {
        Entered?.Invoke();
        _animator.Play(_animationName);

        OnEnter();
    }

    public void Exit()
    {
        Exited?.Invoke();
        OnExit();
    }

    public virtual void FixedUpdate() { }
    public virtual void Update() { }
    protected virtual void OnEnter() { }
    protected virtual void OnExit() { }
}