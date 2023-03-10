using UnityEngine;

public class MainCamera : MonoBehaviourWrapper
{
    [SerializeField] private Camera _camera;
    
    public void Init(CameraData data)
    {
        CameraClampingSettingsFactory cameraClampingSettingsFactory = new(data.Borders, _camera);
        CameraClampingSettings settings = cameraClampingSettingsFactory.Create();
        CameraBordersWithOrientation borders = new(settings, data.SwipeHandler);
        CharacterCapture characterCapture = new(data.Character, transform, borders);
        CameraAnimationHandler cameraAnimationHandler = new(data, _camera, characterCapture);
        
        SetDependencies(new IUnityCallback[]
        {
            borders,
            characterCapture,
            cameraAnimationHandler,
            new CameraRotation(data.Character, transform),
        });
    }
}