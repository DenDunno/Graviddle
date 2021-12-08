using UnityEngine;


public class CharacterSpriteFlipping : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer = null;


    public void FlipCharacter(Movement movement)
    {
        _spriteRenderer.flipX = (movement == Movement.Left);
    }
}