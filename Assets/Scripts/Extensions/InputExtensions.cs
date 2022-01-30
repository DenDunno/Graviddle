using UnityEngine;


public static class InputExtensions
{
    public static Vector2 GetTouchDelta()
    {
        Vector2 delta = Vector2.zero;

        if (Input.touchCount > 0)
        {
            delta = Input.GetTouch(0).deltaPosition;
        }
        
        return delta;
    }
}