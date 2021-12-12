using UnityEngine;
using UnityEngine.EventSystems;


public class CharacterInputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler , IBeginDragHandler 
{
    [SerializeField] private Movement _movement = Movement.Stop;
    [SerializeField] private MoveDirection _moveDirection = null;
    [SerializeField] private CharacterSpriteFlipping _spriteFlipping = null;


    public void OnPointerDown(PointerEventData eventData)
    {
        _moveDirection.MoveCharacter(_movement);
        _spriteFlipping.FlipCharacter(_movement);
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
            _moveDirection.StopCharacter();
        }
    }
}