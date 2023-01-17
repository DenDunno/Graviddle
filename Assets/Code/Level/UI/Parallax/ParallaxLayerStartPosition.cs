using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ParallaxLayerStartPosition : MonoBehaviour
{
    [SerializeField] private ParallaxSide _parallaxSide = ParallaxSide.Left;
    [SerializeField] private float _offset;

    private enum ParallaxSide
    {
        Left = -1,
        Right = 1
    }

    private void Start()
    {
        var rectTransform = GetComponent<RectTransform>();

        float imageWidth = rectTransform.rect.width + _offset;
        rectTransform.anchoredPosition = new Vector2(imageWidth * (int) _parallaxSide, rectTransform.anchoredPosition.y);
    }
}