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


    public static void SetYScale(this Transform transform, float value)
    {
        transform.localScale = new Vector3(transform.localScale.x, value, transform.localScale.z);
    }


    public static void SetXScale(this Transform transform, float value)
    {
        transform.localScale = new Vector3(value, transform.localScale.y, transform.localScale.z);
    }
    

    public static void SetYLocalPosition(this Transform transform, float value)
    {
        transform.localPosition = new Vector3(transform.localPosition.x, value, transform.localPosition.z);
    }
}