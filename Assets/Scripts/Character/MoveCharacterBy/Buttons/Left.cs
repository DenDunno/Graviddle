using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Left : ControlButton, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        _buttonsControl.MoveLeft();
    }
}
