using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class MenuParallaxLayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    private RectTransform _transform;

    private void Start()
    {
        _transform = GetComponent<RectTransform>();
    }

    public void Update()
    {
        _transform.anchoredPosition += Vector2.left * _speed * Time.deltaTime;

        if (_transform.anchoredPosition.x <= -_transform.rect.width)
        {
            _transform.anchoredPosition = new Vector2(0, _transform.anchoredPosition.y);
        }
    }
}