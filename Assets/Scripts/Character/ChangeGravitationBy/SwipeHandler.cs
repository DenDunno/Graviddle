using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SwipeHandler : GravityChangeType, IBeginDragHandler, IDragHandler
{
    private float _swipeSensitivity = 1.0f;


    private void Start() // удаляем ненужный джойстик
    {
        GameObject fixedJoystick = GetComponentInChildren<FixedJoystick>().gameObject;
        Destroy(fixedJoystick);
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        DefineTurn(_swipeSensitivity, eventData.delta.x, eventData.delta.y);
    }


    public void OnDrag(PointerEventData eventData)
    {
    }


    public override bool CheckTouch(Touch touch)
    {
        return touch.phase != TouchPhase.Moved;
    }
}





