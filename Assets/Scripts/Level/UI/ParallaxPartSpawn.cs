using UnityEngine;


[RequireComponent(typeof(RectTransform))]
public class ParallaxPartSpawn : MonoBehaviour
{
    [SerializeField] private Part _parallaxSide = Part.Left;
    [SerializeField] private float _offset = 0;


    private void Start()
    {
        var rectTransform = GetComponent<RectTransform>();

        float imageWidth = rectTransform.rect.width + _offset;
        rectTransform.anchoredPosition = new Vector2(imageWidth * (int) _parallaxSide, rectTransform.anchoredPosition.y);
    }
}