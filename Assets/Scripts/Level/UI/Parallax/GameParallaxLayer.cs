using System;
using UnityEngine;


[RequireComponent(typeof(RectTransform))]
public class GameParallaxLayer : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera = null;
    [SerializeField] [Range(0, 1)] private float _parallaxEffect = 0;
    [SerializeField] private SwipeHandler _swipeHandler = null;

    private RectTransform _layer = null;
    private float _anchor = 0;
    private float _imageWidth;
    private readonly float _parallaxSpeed = 100f;
    private GravityDirection _gravityDirection = GravityDirection.Down;


    private void Start()
    {
        _layer = GetComponent<RectTransform>();
        _imageWidth = _layer.rect.width;
    }


    private void OnEnable()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }


    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }


    private void Update()
    {
        float parallaxDistance = GetParallaxDistance();
        MoveLayer(parallaxDistance);
        TryChangeAnchor(parallaxDistance);
    }


    private float GetParallaxDistance()
    {
        float cameraPosition = _gravityDirection switch
        {
            GravityDirection.Down => _mainCamera.transform.position.x,
            GravityDirection.Up => -_mainCamera.transform.position.x,
            GravityDirection.Right => _mainCamera.transform.position.y,
            GravityDirection.Left => -_mainCamera.transform.position.y,
            _ => throw new ArgumentOutOfRangeException()
        };

        return cameraPosition * _parallaxEffect * _parallaxSpeed;
    }


    private void MoveLayer(float parallaxDistance)
    {
        _layer.anchoredPosition = new Vector3(_anchor - parallaxDistance, _layer.anchoredPosition.y);
    }


    private void TryChangeAnchor(float parallaxDistance)
    {
        if (parallaxDistance > _anchor + _imageWidth)
        {
            _anchor += _imageWidth;
        }

        else if (parallaxDistance < _anchor - _imageWidth)
        {
            _anchor -= _imageWidth;
        }
    }


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        _gravityDirection = gravityDirection;
    }
}