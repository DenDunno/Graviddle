using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;


public class VictorySceneChoice : MonoBehaviour
{
    [SerializeField] private AssetReference _transitToLevelReference;
    
    
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
        var sceneTransit = await LocalAssetLoader.Load<SceneTransit>(_transitToLevelReference);
        await sceneTransit.MakeTransition(sceneIndex);
        LocalAssetLoader.Unload(sceneTransit.gameObject);
    }
}