using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Left : MovementButtons, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Movement = Move.LEFT;
    }
}
