using UnityEngine;


public class CameraCapturePresenter : MonoBehaviour, IRestartableComponent
{
    [SerializeField] private CameraCapture _targetCapture;
    private CameraCapture[] _cameraCaptures;


    private void Start()
    {
        _cameraCaptures = FindObjectsOfType<CameraCapture>();
    }


    public void CaptureObject(CameraCapture objectToBeCaptured)
    {
        UntieAll();

        _targetCapture = objectToBeCaptured;
        _targetCapture.enabled = true;
    }


    public void UntieAll()
    {
        _cameraCaptures.ForEach(cameraCapture => cameraCapture.enabled = false);
    }


    void IRestartableComponent.Restart()
    {
        _targetCapture.ResetCameraTransform();
    }
}