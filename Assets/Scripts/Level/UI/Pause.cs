using UnityEngine;


public class Pause : MonoBehaviour
{
    [SerializeField] private SceneTransit _sceneTransit = null;
    [SerializeField] private Canvas _touchCanvas = null;


    public void SwitchPauseMenu(bool active)
    {
        gameObject.SetActive(active);
        _touchCanvas.gameObject.SetActive(!active);

        Time.timeScale = active ? 0 : 1;
    }


    public void BackToMenu()
    {
        SwitchPauseMenu(false);
        _sceneTransit.SpawnTransit(0);
    }
}

