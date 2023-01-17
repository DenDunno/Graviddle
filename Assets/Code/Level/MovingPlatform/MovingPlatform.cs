using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        TryTieTransformToPlatform(collider2d, transform);
    }

    private void OnTriggerExit2D(Collider2D collider2d)
    {
        TryTieTransformToPlatform(collider2d, null);
    }

    private void TryTieTransformToPlatform(Collider2D collider2d , Transform parent)
    {
        if (collider2d.TryGetComponent(out PlatformGrabbable character))
        {
            character.transform.SetParent(parent);
        }
    }
}