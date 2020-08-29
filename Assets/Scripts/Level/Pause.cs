using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void On_Off_PauseMenu(bool active)
    {
        gameObject.SetActive(active);
        Time.timeScale = active ? 0 : 1;
    }

    public void Back_to_menu()
    {
        Time.timeScale = 1;

        Transit transit;
        transit = Resources.Load<Transit>("Prefabs/Menu/Transit"); ;
        transit.SpawnTransit(0);
    }
}
