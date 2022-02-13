using UnityEngine;

public static class CharacterMovementInEditorSpawner
{
    #if UNITY_EDITOR
    
    [RuntimeInitializeOnLoadMethod]
    private static void SpawnCharacterMovementInEditor()
    {
        var moveDirection = Object.FindObjectOfType<MoveDirection>();

        if (moveDirection != null)
        {
            moveDirection.enabled = false;
            var movementInEditor = moveDirection.gameObject.AddComponent<CharacterMovementInEditor>();
            movementInEditor.Init(moveDirection, Object.FindObjectOfType<SwipeHandler>(true));
        }
    }
    
    #endif
}