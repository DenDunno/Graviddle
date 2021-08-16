using UnityEngine;
using UnityEngine.EventSystems;


public class MovementButton : MonoBehaviour , IBeginDragHandler , IDragHandler , IEndDragHandler
{
    [SerializeField] private Movement _movement = Movement.Stop;
    [SerializeField] private CharacterMovement _characterMovement = null;


    public void OnBeginDrag(PointerEventData eventData)
    {
        _characterMovement.MoveCharacter(_movement);
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        _characterMovement.StopCharacter();
    }


    public void OnDrag(PointerEventData eventData)
    {
    }


    private void OnDisable()
    {
        _characterMovement.StopCharacter();
    }
}