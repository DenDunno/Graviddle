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

        Transit transit;
        transit = Resources.Load<Transit>("Prefabs/Menu/Transit");
        transit.SpawnTransit(0);
    }
}

