using System;
using UnityEngine;


[Serializable]
public class CharacterSpriteFlipping 
{
    [SerializeField] private SpriteRenderer _spriteRenderer;


    public void FlipCharacter(MovementState movementState)
    {
        _spriteRenderer.flipX = (movementState == MovementState.Left);
    }
}