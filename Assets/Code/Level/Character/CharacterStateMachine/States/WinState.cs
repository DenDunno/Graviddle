using UnityEngine;

public class WinState : CharacterState
{
    private readonly Rigidbody2D _rigidbody;

    public WinState(Animator character) : base(character, AnimationsName.Fall)
    {
        _rigidbody = character.GetComponent<Rigidbody2D>();
    }

    protected override void OnEnterState()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.isKinematic = true;
    }
}