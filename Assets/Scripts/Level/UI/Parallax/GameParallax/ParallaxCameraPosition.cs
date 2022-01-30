﻿using System;
using UnityEngine;


[Serializable]
public class ParallaxCameraPosition 
{
    [SerializeField] private Camera _mainCamera;


    public float GetCameraPosition(GravityDirection gravityDirection)
    {
        return gravityDirection switch
        {
            GravityDirection.None => _mainCamera.transform.position.x,
            GravityDirection.Down => _mainCamera.transform.position.x,
            GravityDirection.Up => -_mainCamera.transform.position.x,
            GravityDirection.Left => -_mainCamera.transform.position.y,
            GravityDirection.Right => _mainCamera.transform.position.y,
            _ => throw new ArgumentOutOfRangeException(nameof(gravityDirection), gravityDirection, null)
        };
    }
}