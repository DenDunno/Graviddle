using UnityEngine;
using UnityEngine.EventSystems;


public class MovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Movement _movement = Movement.Stop;
    [SerializeField] private CharacterMovement _characterMovement = null;


    public void OnPointerDown(PointerEventData eventData)
    {
        _characterMovement.MoveCharacter(_movement);
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        _characterMovement.StopCharacter();
    }


    private void OnDisable()
    {
        _characterMovement.StopCharacter();
    }
}