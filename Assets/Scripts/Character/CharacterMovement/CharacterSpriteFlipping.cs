using UnityEngine;


public class CharacterSpriteFlipping : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;


    public void FlipCharacter(MovementState movementState)
    {
        _spriteRenderer.flipX = (movementState == MovementState.Left);
    }
}