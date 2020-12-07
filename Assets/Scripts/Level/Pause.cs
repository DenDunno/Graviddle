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

        SceneTransit transit;
        transit = Resources.Load<SceneTransit>("Prefabs/Menu/SceneTransit");
        transit.SpawnTransit(0);
    }
}

