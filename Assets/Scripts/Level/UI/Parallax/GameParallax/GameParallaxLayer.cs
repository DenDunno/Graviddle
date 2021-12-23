using UnityEngine;


public class GameParallaxLayer : MonoBehaviour
{
    [SerializeField] private ParallaxCameraPosition _parallaxCameraPosition = null;
    [SerializeField] private ParallaxLayerClamping _parallaxLayerClamping = null;
    [SerializeField] [Range(0, 1)] private float _parallaxEffect = 0;
    [SerializeField] private SwipeHandler _swipeHandler = null;
    [SerializeField] private RectTransform _layer = null;
    private GravityDirection _gravityDirection;
    private float _lastCameraPosition;


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
        float newCameraPosition = _parallaxCameraPosition.GetCameraPosition(_gravityDirection);

        _layer.anchoredPosition = GetParallaxLayerPosition(newCameraPosition);

        _lastCameraPosition = newCameraPosition;
    }


    private Vector2 GetParallaxLayerPosition(float newCameraPosition)
    {
        const float parallaxSpeed = 3.5f;

        float cameraDiffPosition = newCameraPosition - _lastCameraPosition;
        float targetXParallaxPosition = cameraDiffPosition * _parallaxCameraPosition.CameraMagnitude * _parallaxEffect * parallaxSpeed;
        targetXParallaxPosition = _layer.anchoredPosition.x - targetXParallaxPosition;

        _parallaxLayerClamping.ClampParallaxLayerPosition(ref targetXParallaxPosition);

        return new Vector2(targetXParallaxPosition, _layer.anchoredPosition.y);
    }
    

    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        _gravityDirection = gravityDirection;
        _lastCameraPosition = _parallaxCameraPosition.GetCameraPosition(gravityDirection);
    }
}