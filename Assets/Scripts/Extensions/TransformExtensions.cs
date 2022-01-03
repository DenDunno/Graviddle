using UnityEngine;


public static class TransformExtensions
{
    public static void SetPositionWithLocalOffset(this Transform transform, Vector2 position, Vector2 offset)
    {
        transform.position = position;
        transform.localPosition += (Vector3)offset;
    }


    public static void SetPositionAndRotation(this Transform transform, Transform targetTransform)
    {
        transform.position = targetTransform.position;
        transform.rotation = targetTransform.rotation;
    }
}