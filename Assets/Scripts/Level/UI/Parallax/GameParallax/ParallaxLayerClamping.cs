using System;
using UnityEngine;


[Serializable]
public class ParallaxLayerClamping
{
    [SerializeField] private RectTransform _rectTransform = null;
    private float _imageWidth => _rectTransform.rect.width;


    public void ClampParallaxLayerPosition(ref float targetParallaxLayerPosition)
    {
        if (targetParallaxLayerPosition > _imageWidth)
        {
            targetParallaxLayerPosition -= _imageWidth;
        }

        else if (targetParallaxLayerPosition < -_imageWidth)
        {
            targetParallaxLayerPosition += _imageWidth;
        }
    }
}