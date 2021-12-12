using UnityEngine;


public enum Part
{
    Left = -1,
    Centre = 0,
    Right = 1
}


[RequireComponent(typeof(RectTransform))]
public class MenuParallaxLayer : MonoBehaviour
{
    [SerializeField] private Part _parallaxPart = Part.Left;
    [SerializeField] private float _speed = 0;
    private RectTransform _transform;
    private float _leftBorder;
    private float _rightBorder;


    private void Start()
    {
        _transform = GetComponent<RectTransform>();

        _leftBorder = -_transform.rect.width;
        _rightBorder = _transform.rect.width;

        if (_parallaxPart != Part.Centre)
        {
            float xPosition = (int)_parallaxPart * _transform.rect.width;

            _transform.anchoredPosition = new Vector2(xPosition , _transform.anchoredPosition.y);
        }
    }
    

    public void Update()
    {
        _transform.anchoredPosition += Vector2.left * _speed * Time.deltaTime;

        if (_transform.anchoredPosition.x <= _leftBorder)
        {
            _transform.anchoredPosition = new Vector2(_rightBorder, _transform.anchoredPosition.y);
        }
    }
}
