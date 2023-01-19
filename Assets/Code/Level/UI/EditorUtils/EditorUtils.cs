using UnityEngine;

public static class EditorUtils 
{
    [RuntimeInitializeOnLoadMethod]
    private static void OnRuntimeMethodLoad()
    {
        #if UNITY_EDITOR

        UI ui = Object.FindObjectOfType<UI>();
        
        if (ui != null)
        {
            ui.Show<GameplayPanel>();
        }

        #endif  
    }
}
