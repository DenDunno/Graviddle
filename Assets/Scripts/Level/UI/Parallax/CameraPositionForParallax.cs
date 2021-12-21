using System;
using UnityEngine;


public class CameraPositionForParallax : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeHandler = null;
    [SerializeField] private Camera _mainCamera = null;

    public float CameraPosition { get; private set; }


    private void OnEnable()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }


    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        CameraPosition = gravityDirection switch
        {
            GravityDirection.Down => _mainCamera.transform.position.x,
            GravityDirection.Up => -_mainCamera.transform.position.x,
            GravityDirection.Left => -_mainCamera.transform.position.y,
            GravityDirection.Right => _mainCamera.transform.position.y,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}