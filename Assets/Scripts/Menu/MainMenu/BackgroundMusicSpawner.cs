using UnityEngine;


public static class BackgroundMusicSpawner
{
    private const string _backgroundMusicName = "BackgroundMusic";
    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void TrySpawnBackgroundMusic()
    {
        if (Object.FindObjectOfType<BackgroundMusic>() == null) 
        {
            var music = Resources.Load<BackgroundMusic>(_backgroundMusicName);
            Object.DontDestroyOnLoad(Object.Instantiate(music));
        }
    }
}