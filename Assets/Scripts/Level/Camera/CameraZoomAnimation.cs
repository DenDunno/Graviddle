using DG.Tweening;
using UnityEngine;


public class CameraZoomAnimation : MonoBehaviour
{
    private readonly float _zoomOutDuration = 1f;
    private readonly float _zoomInDuration = 0.5f;

    private Camera _camera;
    private LevelZoomCalculator _zoomCalculator;
    private float _horizontalLevelCentre;
    private float _verticalLevelCentre;
    private float _characterZoom;


    public void Init(Camera mainCamera, LevelZoomCalculator zoomCalculator, LevelBorders borders)
    {
        _camera = mainCamera;
        _zoomCalculator = zoomCalculator;
        _horizontalLevelCentre = (borders.Right + borders.Left) / 2f;
        _verticalLevelCentre = (borders.Top + borders.Down) / 2f;
        _characterZoom = mainCamera.orthographicSize;
    }


    public Tween ZoomOutAndMoveToCentre()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Join(transform.DOMoveX(_horizontalLevelCentre, _zoomOutDuration));
        sequence.Join(transform.DOMoveY(_verticalLevelCentre, _zoomOutDuration));
        sequence.Join(ZoomCamera(_characterZoom, _zoomCalculator.GetLevelZoom(), _zoomOutDuration));

        return sequence;
    }


    public Tween ZoomIn()
    {
        return ZoomCamera(_camera.orthographicSize, _characterZoom, _zoomInDuration);
    }


    private Tween ZoomCamera(float zoomFrom, float zoomTo, float duration)
    {
        return DOTween.To(x => _camera.orthographicSize = x, zoomFrom, zoomTo, duration);
    }
} 