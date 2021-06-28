using System;
using UnityEngine;


public class CameraBorders : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeHandler = null;

    [SerializeField] private float _leftBorder = -10;
    [SerializeField] private float _rightBorder = 10;
    [SerializeField] private float _downBorder = -10;


    private void OnEnable()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }
    

    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }


    public void ClampCamera(ref Vector3 cameraPosition)
    {
        cameraPosition.x = Mathf.Clamp(cameraPosition.x, _leftBorder, _rightBorder);
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, _downBorder, cameraPosition.y);
    }


    private void OnGravityChanged(GravityDirection gravityDirection, bool lift)
    {
    }
}