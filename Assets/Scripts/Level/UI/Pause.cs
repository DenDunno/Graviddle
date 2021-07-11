using UnityEngine;


public class Pause : MonoBehaviour
{
    [SerializeField] private SceneTransit _sceneTransit = null;
    [SerializeField] private GameObject _touchCanvas = null;


    public void SwitchPauseMenu(bool active)
    {
        gameObject.SetActive(active);
        _touchCanvas.SetActive(!active);

        Time.timeScale = active ? 0 : 1;
    }


    public void BackToMenu()
    {
        SwitchPauseMenu(false);
        _sceneTransit.SpawnTransit(0);
    }
}

