using UnityEngine;

public static class ColliderExtensions
{
    public static void ClearCollisionList(this Collider2D collider2D)
    {
        collider2D.enabled = false;
        collider2D.enabled = true;
    }
}