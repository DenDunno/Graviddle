using UnityEngine;


public class CaptureClick : ButtonClick
{
    [SerializeField] private CameraCapturePresenter _cameraCapturePresenter = null;
    [SerializeField] private CameraCapture _capture = null;


    protected override void OnButtonClick()
    {
        _cameraCapturePresenter.CaptureObject(_capture);
    }
}