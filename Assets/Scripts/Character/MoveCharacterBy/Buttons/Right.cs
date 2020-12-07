using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Right : ControlButton, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        _buttonsControl.MoveRight();
    }
}
