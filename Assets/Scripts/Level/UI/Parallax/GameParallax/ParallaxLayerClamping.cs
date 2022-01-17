using UnityEngine;


public class ParallaxLayerClamping
{
    private readonly float _screenWidth;

    
    public ParallaxLayerClamping()
    {
        _screenWidth = Screen.width;
    }
    
    
    public void ClampParallaxLayerPosition(ref float targetParallaxLayerPosition)
    {
        Debug.Log($"Image width {_screenWidth}, real = {targetParallaxLayerPosition}");
        if (targetParallaxLayerPosition > _screenWidth)
        {
            targetParallaxLayerPosition -= _screenWidth;
        }

        else if (targetParallaxLayerPosition < -_screenWidth)
        {
            targetParallaxLayerPosition += _screenWidth;
        }
    }
}