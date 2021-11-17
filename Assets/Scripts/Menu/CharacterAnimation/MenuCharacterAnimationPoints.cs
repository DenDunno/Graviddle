using System.Collections.Generic;
using UnityEngine;


public static class MenuCharacterAnimationPoints 
{
    public static List<AnimationPath> GetAnimationPoints(RectTransform canvas , float offset)
    {
        float widthOffset = canvas.rect.width / offset;

        float height = canvas.rect.height;
        float width = canvas.rect.width;

        return new List<AnimationPath>()
        {
            new AnimationPath(new Vector2(widthOffset , widthOffset) , new Vector2(widthOffset , -height - widthOffset)),
            new AnimationPath(new Vector2(width + widthOffset , -height + widthOffset) , new Vector2(-widthOffset , -height + widthOffset)),
            new AnimationPath(new Vector2(width - widthOffset , -height - widthOffset) , new Vector2(width - widthOffset , widthOffset)),
            new AnimationPath(new Vector2(-widthOffset , -widthOffset) , new Vector2(width + widthOffset , -widthOffset)),
        };
    }
}
