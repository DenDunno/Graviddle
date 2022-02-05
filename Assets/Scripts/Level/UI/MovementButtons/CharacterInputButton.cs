using UnityEngine;
using UnityEngine.EventSystems;


public class CharacterInputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private MovementState _movementState = MovementState.Stop;
    [SerializeField] private MoveDirection _moveDirection;
    [SerializeField] private CharacterSpriteFlipping _spriteFlipping;
    private bool _isTouching;
    

    public void OnPointerDown(PointerEventData eventData)
    {
        _isTouching = true;
        _spriteFlipping.FlipCharacter(_movementState);
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        OnDisable();
    }
    
    
    private void OnDisable()
    {
        _isTouching = false;
        _moveDirection.SetMovementDirection(MovementState.Stop);
    }
    
    
    private void Update()
    {
        if (_isTouching)
        {
            _moveDirection.SetMovementDirection(_movementState);
        }
    }
}