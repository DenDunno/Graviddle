using System.Collections.Generic;
using UnityEngine;

public static class MenuCharacterAnimationPoints 
{
    public static List<AnimationPath> GetAnimationPoints(RectTransform rectTransform)
    {
        const float offset = 9;
        float widthOffset = rectTransform.rect.width / offset;

        float height = rectTransform.rect.height;
        float width = rectTransform.rect.width;

        return new List<AnimationPath>()
        {
            new(new Vector2(widthOffset, widthOffset), new Vector2(widthOffset, -height - widthOffset)),
            new(new Vector2(width + widthOffset, -height + widthOffset), new Vector2(-widthOffset, -height + widthOffset)),
            new(new Vector2(width - widthOffset, -height - widthOffset), new Vector2(width - widthOffset , widthOffset)),
            new(new Vector2(-widthOffset, -widthOffset), new Vector2(width + widthOffset, -widthOffset)),
        };
    }
}
