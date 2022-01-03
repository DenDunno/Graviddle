using UnityEngine;


[RequireComponent(typeof(CameraZoomAnimation))]
[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(CameraBordersWithOrientation))]
public class CameraMediator : MonoBehaviour
{
    [SerializeField] private LevelBorders _levelBorders = null;
    [SerializeField] private CameraZoom _cameraZoom = null;


    private void Start()
    {
        var bordersWithOrientation = GetComponent<CameraBordersWithOrientation>();
        var mainCamera = GetComponent<Camera>();
        var cameraZoomAnimation = GetComponent<CameraZoomAnimation>();
        var levelZoomCalculator = GetComponent<LevelZoomCalculator>();
        var cameraSizeFitter = new CameraSizeFitter(mainCamera);

        cameraSizeFitter.FitCameraSize();
        CameraClampingSettings settings = CameraClampingSettingsFactory.CreateClampingSettings(_levelBorders, mainCamera);

        bordersWithOrientation.Init(settings);
        cameraZoomAnimation.Init(mainCamera, levelZoomCalculator, _levelBorders);
        levelZoomCalculator.Init(mainCamera, _levelBorders);
        _cameraZoom.Init(mainCamera, levelZoomCalculator);
    }
}