using System;
using UnityEngine;

public class ParallaxCameraPosition 
{
    private readonly Transform _cameraTransform;

    public ParallaxCameraPosition(Transform cameraTransform)
    {
        _cameraTransform = cameraTransform;
    }

    public float GetCameraPosition(GravityDirection gravityDirection)
    {
        return gravityDirection switch
        {
            GravityDirection.Down => _cameraTransform.position.x,
            GravityDirection.Up => -_cameraTransform.position.x,
            GravityDirection.Left => -_cameraTransform.position.y,
            GravityDirection.Right => _cameraTransform.position.y,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}