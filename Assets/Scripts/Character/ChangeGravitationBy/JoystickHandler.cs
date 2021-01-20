using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class JoystickHandler : GravityChangeType
{
    private float _joystickSensitivity = 0.3f;


    public void OnPointerDown(float joystickHorizontal , float joystickVertical)
    {
        if (_gravityWasChanged == false)
            DefineTurn(_joystickSensitivity, joystickHorizontal, joystickVertical);
    }


    public void OnPointerUp()
    {
        _gravityWasChanged = false;
    }


    public override bool CheckTouch(Touch touch)
    {
        return Joystick.JoystickIsTouched == false;
    }
}




