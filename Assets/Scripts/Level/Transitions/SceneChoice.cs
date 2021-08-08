using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChoice : MonoBehaviour
{
    [SerializeField] private SceneTransit _sceneTransit = null;


    public void RestartLevel()
    {
        _sceneTransit.SpawnTransit(SceneManager.GetActiveScene().buildIndex);
    }


    public void LaunchNextLevel()
    {
        _sceneTransit.SpawnTransit(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void ReturnToMainMenu()
    {
        _sceneTransit.SpawnTransit(0);
    }
}