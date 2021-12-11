using UnityEngine;
using UnityEngine.UI;


public class GameParallax : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera = null;
    [SerializeField] private RectTransform _layer = null;
    [SerializeField] [Range(0, 1)] private float _parallaxEffect = 0;

    private float _layerWidth;
    private float _startPosition;


    private void Start()
    {
        _layerWidth = _layer.rect.width;
        _startPosition = _layer.anchoredPosition.x;
    }


    private void Update()
    {
        float distance = _mainCamera.transform.position.x * _parallaxEffect * 100;

        _layer.anchoredPosition = new Vector2(_startPosition - distance, _layer.anchoredPosition.y);
    }
}