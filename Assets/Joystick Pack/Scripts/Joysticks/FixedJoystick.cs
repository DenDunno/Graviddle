using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystick : Joystick
{
    private JoystickHandler _joystickHandler;

    protected override void Start()
    {
        base.Start();
        _joystickHandler = GetComponentInParent<JoystickHandler>();
    }


    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        _joystickHandler.OnPointerDown(Horizontal , Vertical);
    }


    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _joystickHandler.OnPointerUp();
    }
}