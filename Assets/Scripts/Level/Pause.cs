using UnityEngine;


public class Pause : MonoBehaviour
{
    public void SwitchPauseMenu(bool active)
    {
        gameObject.SetActive(active);
        Time.timeScale = active ? 0 : 1;
    }


    public void BackToMenu()
    {
        SwitchPauseMenu(false);

        var sceneTransit = Resources.Load<SceneTransit>("SceneTransit");
        sceneTransit.SpawnTransit(0);
    }
}

