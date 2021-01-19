using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Settings : MonoBehaviour
{
    public static Type GravityChangeType
    {
        get
        {
            if (PlayerPrefs.HasKey("GravityChangeType") == true)
                return _gravityChangeTypes[PlayerPrefs.GetInt("GravityChangeType")];

            else
                return _gravityChangeTypes[0];
        }
    }

    public static Type MoveControlType
    {
        get
        {
            if (PlayerPrefs.HasKey("MoveControlType") == true)
                return _moveControlTypes[PlayerPrefs.GetInt("MoveControlType")];

            else
                return _moveControlTypes[0];
        }
    }


    private static List<Type> _gravityChangeTypes = new List<Type>()
    {
        {Type.GetType("SwipeHandler") },
        {Type.GetType("JoystickHandler") }
    };

    private static List<Type> _moveControlTypes = new List<Type>()
    {
        {Type.GetType("MovementButtons") },
        {Type.GetType("TapHandler") }
    };




    public void OnChooseGravityChangeType(int _enum)
    {
        PlayerPrefs.SetInt("GravityChangeType", _enum);
    }


    public void OnChooseMoveType(int _enum)
    {
        PlayerPrefs.SetInt("MoveControlType", _enum);
    }
}

