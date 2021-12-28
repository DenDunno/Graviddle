using DG.Tweening;
using UnityEngine;


public class CameraZoomAnimation : MonoBehaviour
{
    private readonly float _duration = 1f;

    private CameraBordersWithOrientation _borders;
    private Camera _camera;
    private float _startCameraSize;
    
    private float _horizontalLevelCentre => (_borders.Right + _borders.Left) / 2;
    private float _verticalLevelCentre => (_borders.Top + _borders.Down) / 2;


    public void Init(CameraBordersWithOrientation borders, Camera mainCamera)
    {
        _borders = borders;
        _camera = mainCamera;
        _startCameraSize = _camera.orthographicSize;
    }


    public Tween ZoomOutAndMoveToCentre()
    {
        Sequence sequence = DOTween.Sequence();

        const float cameraZoom = 1.5f;
        float zoomFrom = _camera.orthographicSize;
        float zoomTo = _camera.orthographicSize * cameraZoom;

        sequence.Join(transform.DOMoveX(_horizontalLevelCentre, _duration));
        sequence.Join(transform.DOMoveY(_verticalLevelCentre, _duration));
        sequence.Join(ZoomCamera(zoomFrom, zoomTo));

        return sequence;
    }


    public Tween ZoomIn()
    {
        return ZoomCamera(_camera.orthographicSize, _startCameraSize);
    }


    private Tween ZoomCamera(float zoomFrom, float zoomTo)
    {
        return DOTween.To(x => _camera.orthographicSize = x, zoomFrom, zoomTo, _duration);
    }
} 