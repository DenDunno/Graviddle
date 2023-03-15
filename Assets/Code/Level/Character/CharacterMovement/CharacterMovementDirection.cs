using System;
using UnityEngine;

[Serializable]
public class CharacterMovementDirection : IUpdate
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private CharacterSpriteFlipping _characterSpriteFlipping;
    private IGravityState _gravityState;

    public Vector2 Direction { get; private set; }

    public void Init(IGravityState gravityState)
    {
        _gravityState = gravityState;
    }
    
    void IUpdate.Update()
    {
        Direction = _gravityState.Data.Rotation * _input.Input;
        _characterSpriteFlipping.FlipCharacter(_input.State);
    }
}