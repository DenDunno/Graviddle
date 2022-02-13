using UnityEngine;


public class MovingPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        TieCharacterToTransform(collider2d, transform);
    }


    private void OnTriggerExit2D(Collider2D collider2d)
    {
        TieCharacterToTransform(collider2d, null);
    }


    private void TieCharacterToTransform(Collider2D collider2d , Transform parent)
    {
        if (collider2d.TryGetComponent(out Character character))
        {
            character.transform.SetParent(parent);
        }
    }
}