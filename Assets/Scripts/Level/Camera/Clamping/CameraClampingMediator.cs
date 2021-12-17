using UnityEngine;


[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(CameraBordersWithOrientation))]
public class CameraClampingMediator : MonoBehaviour
{
    [SerializeField] private LevelBorders _levelBorders = null;


    private void Start()
    {
        var cameraSizeFitter = new CameraSizeFitter();
        var borders = GetComponent<CameraBordersWithOrientation>();
        var mainCamera = GetComponent<Camera>();

        cameraSizeFitter.FitCameraSize(mainCamera);

        CameraClampingSettings settings = CameraClampingSettingsFactory.CreateClampingSettings(_levelBorders, mainCamera);
        borders.Init(settings);
    }
}