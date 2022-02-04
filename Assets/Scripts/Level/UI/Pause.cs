using System.Threading.Tasks;
using UnityEngine;


public class Pause : MonoBehaviour
{
    [SerializeField] private SceneTransit _sceneTransit;


    public void ToggleTimeScale(bool active)
    {
        Time.timeScale = active ? 0 : 1;
    }


    public async Task BackToMenu()
    {
        ToggleTimeScale(false);
        await _sceneTransit.MakeTransition(0);
    }
}

