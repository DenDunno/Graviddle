using UnityEngine;

public static class CharacterMovementInEditorSpawner
{
    #if UNITY_EDITOR
    
    [RuntimeInitializeOnLoadMethod]
    private static void SpawnCharacterMovementInEditor()
    {
        var character = Object.FindObjectOfType<Character>();

        if (character != null)
        {
        }
    }
    
    #endif
}