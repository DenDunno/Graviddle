using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VictorySceneChoice : MonoBehaviour
{
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
        var sceneTransit = await LocalAssetLoader.Load<SceneTransit>("TransitToLevel");
        await sceneTransit.MakeTransition(sceneIndex);
        LocalAssetLoader.Unload(sceneTransit.gameObject);
    }
}