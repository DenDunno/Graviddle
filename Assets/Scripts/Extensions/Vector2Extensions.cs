using UnityEngine;


public static class Vector2Extensions
{
    public static float GetDiffInMagnitude(this Vector2 first, Vector2 second)
    {
        return (first - second).magnitude;
    }
}