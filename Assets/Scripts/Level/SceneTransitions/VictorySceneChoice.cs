using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VictorySceneChoice : MonoBehaviour
{
    [SerializeField] private LocalAssetLoader _transitToLevelLoader;
    
    
    public async void RestartLevel()
    {
        await TransitToScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    public async void LaunchNextLevel()
    {
        await TransitToScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    private async UniTask TransitToScene(int sceneIndex)
    {
        var sceneTransit = await _transitToLevelLoader.Load<SceneTransit>();
        await sceneTransit.MakeTransition(sceneIndex);
        _transitToLevelLoader.Unload();
    }
}