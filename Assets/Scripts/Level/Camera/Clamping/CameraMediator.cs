using UnityEngine;


[RequireComponent(typeof(CameraZoomAnimation))]
[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(CameraBordersWithOrientation))]
public class CameraMediator : MonoBehaviour
{
    [SerializeField] private LevelBorders _levelBorders = null;


    private void Start()
    {
        var cameraSizeFitter = new CameraSizeFitter();
        var borders = GetComponent<CameraBordersWithOrientation>();
        var mainCamera = GetComponent<Camera>();
        var cameraZoomAnimation = GetComponent<CameraZoomAnimation>();

        cameraSizeFitter.FitCameraSize(mainCamera);

        CameraClampingSettings settings = CameraClampingSettingsFactory.CreateClampingSettings(_levelBorders, mainCamera);

        borders.Init(settings);
        cameraZoomAnimation.Init(borders, mainCamera);
    }
}