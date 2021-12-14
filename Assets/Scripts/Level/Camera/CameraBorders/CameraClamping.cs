using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraClamping : MonoBehaviour
{
    [SerializeField] private LevelBorders _levelBorders = null;
    private CameraClampingSettings _cameraClampingSettings;


    private void Start()
    {
        var mainCamera = GetComponent<Camera>();
        var clampingSettingsFactory = new CameraClampingSettingsFactory(mainCamera);

        _cameraClampingSettings = clampingSettingsFactory.CreateClampingSettings(_levelBorders);
    }


    public void ClampCamera(ref Vector3 cameraPosition)
    {
    }
}