using UnityEngine;
using UnityEngine.EventSystems;


public class CharacterInputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler 
{
    [SerializeField] private MovementState _movementState = MovementState.Stop;
    [SerializeField] private MoveDirection _moveDirection;
    [SerializeField] private CharacterSpriteFlipping _spriteFlipping;


    public void OnPointerDown(PointerEventData eventData)
    {
        _moveDirection.SetMovementDirection(_movementState);
        _spriteFlipping.FlipCharacter(_movementState);
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        OnDisable();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        OnPointerDown(eventData);
    }


    private void OnDisable()
    {
        if (_moveDirection != null)
        {
            _moveDirection.SetMovementDirection(MovementState.Stop);
        }
    }
}