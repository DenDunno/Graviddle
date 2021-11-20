using UnityEngine;


[RequireComponent(typeof(RectTransform))]
public class ParallaxLayer : MonoBehaviour
{
    [SerializeField] private Part _parallaxPart = Part.Left;
    [SerializeField] private float _speed = 0;
    private RectTransform _transform;
    private float _leftBorder;
    private float _rightBorder;

    private enum Part
    {
        Left,
        Centre,
        Right
    }

    private void Start()
    {
        _transform = GetComponent<RectTransform>();

        _leftBorder = -_transform.rect.width;
        _rightBorder = _transform.rect.width;

        if (_parallaxPart != Part.Centre)
        {
            float xPosition = (_parallaxPart == Part.Left ? _leftBorder : _rightBorder);

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
