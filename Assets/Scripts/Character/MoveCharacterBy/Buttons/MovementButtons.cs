using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;



public class MovementButtons : MoveСontrolType, IPointerUpHandler
{
    public void OnPointerUp(PointerEventData eventData)
    {
        Movement = Move.STOP;
    }
}
