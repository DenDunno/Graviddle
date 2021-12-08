using UnityEngine;
using UnityEngine.EventSystems;


public class CharacterInputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler , IBeginDragHandler 
{
    [SerializeField] private Movement _movement = Movement.Stop;
    [SerializeField] private MovementDirection _movementDirection = null;
    [SerializeField] private CharacterSpriteFlipping _spriteFlipping = null;


    public void OnPointerDown(PointerEventData eventData)
    {
        _movementDirection.MoveCharacter(_movement);
        _spriteFlipping.FlipCharacter(_movement);
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        _movementDirection.StopCharacter();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        OnPointerDown(eventData);
    }


    private void OnDisable()
    {
        _movementDirection?.StopCharacter();
    }
}