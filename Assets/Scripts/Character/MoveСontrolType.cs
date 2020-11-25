using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Move
{
    STOP,
    LEFT = -1,
    RIGHT = 1
}

abstract public class MoveСontrolType : MonoBehaviour
{
    public Move Movement;
}





