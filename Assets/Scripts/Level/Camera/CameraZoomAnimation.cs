using DG.Tweening;
using UnityEngine;


public class CameraZoomAnimation : MonoBehaviour
{
    private readonly float _zoomOutDuration = 1f;
    private readonly float _zoomInDuration = 0.75f;

    private Camera _camera;
    private CameraZoomPoints _zoomPoints;
    private float _horizontalLevelCentre;
    private float _verticalLevelCentre;
    

    public void Init(Camera mainCamera, CameraZoomPoints zoomPoints, LevelBorders borders)
    {
        _camera = mainCamera;
        _zoomPoints = zoomPoints;
        _horizontalLevelCentre = (borders.Right + borders.Left) / 2f;
        _verticalLevelCentre = (borders.Top + borders.Down) / 2f;
    }


    public Tween ZoomOutAndMoveToCentre()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Join(transform.DOMoveX(_horizontalLevelCentre, _zoomOutDuration));
        sequence.Join(transform.DOMoveY(_verticalLevelCentre, _zoomOutDuration));
        sequence.Join(ZoomCamera(_zoomPoints.GetCharacterZoom(), _zoomPoints.GetLevelZoom(), _zoomOutDuration));

        return sequence;
    }


    public Tween ZoomIn()
    {
        return ZoomCamera(_camera.orthographicSize, _zoomPoints.GetCharacterZoom(), _zoomInDuration);
    }


    private Tween ZoomCamera(float zoomFrom, float zoomTo, float duration)
    {
        return DOTween.To(x => _camera.orthographicSize = x, zoomFrom, zoomTo, duration);
    }
} 