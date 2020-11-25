using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Joystickk : GravityChangeType
{
    public override void LoadData()
    {
        GameObject fixedJoystick = Instantiate(Resources.Load<GameObject>("Prefabs/Level/FixedJoystick"));
        fixedJoystick.transform.SetParent(transform);
    }
}





