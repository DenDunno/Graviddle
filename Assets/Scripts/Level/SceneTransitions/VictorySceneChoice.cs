using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VictorySceneChoice : MonoBehaviour
{
    [SerializeField] private SceneTransit _sceneTransit;


    public async void RestartLevel()
    {
        await TransitToScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    public async void LaunchNextLevel()
    {
        await TransitToScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    
    public async void ReturnToMenu()
    {
        await TransitToScene(0);
    }


    private async UniTask TransitToScene(int sceneIndex)
    {
        await _sceneTransit.MakeTransition(sceneIndex);
    }
}