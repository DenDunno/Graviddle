using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Settings : MonoBehaviour
{
    private Dictionary<int, Type> GravityChangeType = new Dictionary<int, Type>()
    {
        {0 , Type.GetType("SwipeHandler") },
        {1 , Type.GetType("JoystickHandler") }
    };

    private Dictionary<int, Type> MoveType = new Dictionary<int, Type>()
    {
        {0 , Type.GetType("SwipeHandler") },
        {1 , Type.GetType("JoystickHandler") }
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

