using UnityEngine;


public class Pause : MonoBehaviour
{
    [SerializeField] private SceneTransit _sceneTransit;


    public void ToggleTimeScale(bool active)
    {
        Time.timeScale = active ? 0 : 1;
    }


    public void BackToMenu()
    {
        ToggleTimeScale(false);
        _sceneTransit.SpawnTransit(0);
    }
}

