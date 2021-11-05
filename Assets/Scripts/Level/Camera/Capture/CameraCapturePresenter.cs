using UnityEngine;


public class CameraCapturePresenter : MonoBehaviour
{
    private CameraCapture[] _cameraCaptures;


    private void Start()
    {
        _cameraCaptures = FindObjectsOfType<CameraCapture>();
    }


    public void CaptureObject(CameraCapture objectToBeCaptured)
    {
        UntieAll();

        objectToBeCaptured.enabled = true;
    }


    public void UntieAll()
    {
        _cameraCaptures.ForEach(cameraCapture => cameraCapture.enabled = false);
    }
}