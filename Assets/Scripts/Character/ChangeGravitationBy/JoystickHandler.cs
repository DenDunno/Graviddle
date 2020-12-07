using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class JoystickHandler : GravityChangeType
{
    private FixedJoystick _fixedJoystick;
    private float _joystickSensitivity = 0.3f;

    private void Start()
    {
        _fixedJoystick = GetComponentInChildren<FixedJoystick>();
    }

    public void OnPointerDown()
    {
        if (!_gravityWasChanged)
        DefineTurn(_joystickSensitivity, _fixedJoystick.Horizontal, _fixedJoystick.Vertical);
    }

    public void OnPointerUp()
    {
        _gravityWasChanged = false;
    }

    public override bool CheckTouch(Touch touch)
    {
        return !_fixedJoystick.JoystickIsTouched;
    }
}




