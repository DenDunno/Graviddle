using UnityEngine;
using UnityEngine.EventSystems;


public class MovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler , IBeginDragHandler 
{
    [SerializeField] private Movement _movement = Movement.Stop;
    [SerializeField] private MovementDirection _movementDirection = null;


    private void OnDisable()
    {
        _movementDirection.StopCharacter();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        _movementDirection.MoveCharacter(_movement);
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        _movementDirection.StopCharacter();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        _movementDirection.MoveCharacter(_movement);
    }
}