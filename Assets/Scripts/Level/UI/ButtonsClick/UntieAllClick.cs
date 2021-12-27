using UnityEngine;


public class UntieAllClick : ButtonClick
{
    [SerializeField] private CameraCapturePresenter _cameraCapturePresenter = null;


    protected override void OnButtonClick()
    {
        _cameraCapturePresenter.UntieAll();
    }
}