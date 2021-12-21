using System;
using UnityEngine;


public class GameParallaxLayer : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera = null;
    [SerializeField] [Range(0, 1)] private float _parallaxEffect = 0;
    [SerializeField] private SwipeHandler _swipeHandler = null;
    private RectTransform _layer = null;
    private float _imageWidth;
    private GravityDirection _gravityDirection;
    private float _lastCameraPosition;
    private float _newCameraPosition;
    private float _parallaxSpeed = 150;
    private float _anchor = 0;


    private void Start()
    {
        _layer = GetComponent<RectTransform>();
        _imageWidth = _layer.rect.width;
    }


    private void Update()
    {
        _newCameraPosition = _gravityDirection switch
        {
            GravityDirection.Down => _mainCamera.transform.position.x,
            GravityDirection.Up => -_mainCamera.transform.position.x,
            GravityDirection.Left => -_mainCamera.transform.position.y,
            GravityDirection.Right => +_mainCamera.transform.position.y,
            _ => throw new ArgumentOutOfRangeException()
        };

        float targetPosition = (_lastCameraPosition - _newCameraPosition) * _mainCamera.transform.position.magnitude;
        targetPosition = _layer.anchoredPosition.x + targetPosition * Time.deltaTime * _parallaxSpeed * _parallaxEffect;
        
        TryChangeAnchor(ref targetPosition);

        _layer.anchoredPosition = new Vector2(targetPosition, _layer.anchoredPosition.y);

        _lastCameraPosition = _newCameraPosition;
    }
    

    private void TryChangeAnchor(ref float targetPosition)
    {
        if (targetPosition > _anchor + _imageWidth)
        {
            targetPosition -= _imageWidth;
        }

        else if (targetPosition < _anchor - _imageWidth)
        {
            targetPosition += _imageWidth;
        }
    }


    private void OnEnable()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }


    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        _gravityDirection = gravityDirection;
        _lastCameraPosition = _gravityDirection switch
        {
            GravityDirection.Down => _mainCamera.transform.position.x,
            GravityDirection.Up => -_mainCamera.transform.position.x,
            GravityDirection.Left => -_mainCamera.transform.position.y,
            GravityDirection.Right => +_mainCamera.transform.position.y,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}