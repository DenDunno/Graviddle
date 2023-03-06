﻿using UnityEngine;

public class MainCamera : MonoBehaviourWrapper
{
    [SerializeField] private CameraAnimation _cameraAnimation;
    [SerializeField] private Camera _mainCamera;

    public void Init(CurrentGravityData currentGravityData, SwipeHandler swipeHandler, LevelBorders levelBorders, Character character)
    {
        CameraClampingSettingsFactory cameraClampingSettingsFactory = new(levelBorders, _mainCamera);
        CameraClampingSettings settings = cameraClampingSettingsFactory.Create();
        LevelZoomCalculator zoomCalculator = new(_mainCamera, levelBorders, currentGravityData);
        CameraMovingToCentreAnimation movingToCentreAnimation = new(levelBorders, _mainCamera);
        CameraZoomAnimation zoomAnimation = new(_mainCamera, zoomCalculator);
        CameraBordersWithOrientation borders = new(settings, swipeHandler);

        _cameraAnimation.Init(zoomAnimation, movingToCentreAnimation);

        SetDependencies(new IUnityCallback[]
        {
            borders,
            new CameraRotation(character, transform),
            new CharacterCapture(character, transform, borders)
        });
    }
}