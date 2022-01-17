using UnityEngine;


public class CharacterMovementInEditor : MonoBehaviour
{
    private MoveDirection _moveDirection;
    private CharacterSpriteFlipping _spriteFlipping;
    
    
    private void Start()
    {
        #if !UNITY_EDITOR
        enabled = false;
        return;
        #endif

        _moveDirection = FindObjectOfType<MoveDirection>();
        _spriteFlipping = _moveDirection.GetComponent<CharacterSpriteFlipping>();
    }


    private void Update()
    {
        var movement = (Movement)Input.GetAxisRaw("Horizontal");
        
        _moveDirection.MoveCharacter(movement);
        _spriteFlipping.FlipCharacter(movement);
    }
}