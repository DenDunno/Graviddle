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

        _layer.anchoredPosition = new Vector2(GetParallaxLayerPosition(newCameraPosition), _layer.anchoredPosition.y);

        _lastCameraPosition = newCameraPosition;
    }


    private float GetParallaxLayerPosition(float newCameraPosition)
    {
        const float parallaxSpeed = 600;

        float targetPosition = (newCameraPosition - _lastCameraPosition) * _parallaxCameraPosition.CameraMagnitude;
        targetPosition = _layer.anchoredPosition.x - targetPosition * Time.deltaTime * parallaxSpeed * _parallaxEffect;

        _parallaxLayerClamping.ClampParallaxLayerPosition(ref targetPosition);

        return targetPosition;
    }
    

    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        _gravityDirection = gravityDirection;
        _lastCameraPosition = _parallaxCameraPosition.GetCameraPosition(gravityDirection);
    }
}