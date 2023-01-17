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

    public void Enter()
    {
        _animator.Play(_animationName);

        OnEnterState();
    }

    public virtual void Update() { }
    protected virtual void OnEnterState() { }
}