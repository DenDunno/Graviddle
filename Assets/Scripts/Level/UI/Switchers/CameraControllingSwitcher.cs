﻿using UnityEngine;


public class CameraControllingSwitcher : MonoBehaviour
{
    [SerializeField] private CameraControlling _cameraControlling = null;
    [SerializeField] private CharacterCapture _characterCapture = null;    
    

    public void ToggleCameraTouchControlling(bool cameraControllingEnabled)
    {
        _cameraControlling.enabled = cameraControllingEnabled;
        _characterCapture.enabled = !cameraControllingEnabled;
    }
}