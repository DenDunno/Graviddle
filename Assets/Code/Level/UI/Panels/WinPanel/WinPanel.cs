using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class WinPanel : Panel
{
    [SerializeField] private AssetReference _transitToLevelReference;
    [SerializeField] private WinAnimation _winAnimation;

    protected override UniTask OnShow()
    {
        _winAnimation.Play();

        return base.OnShow();
    }

    public async void RestartLevel()
    {
        await TransitToScene(0);
    }

    public async void LaunchNextLevel()
    {
        await TransitToScene(1);
    }

    private async UniTask TransitToScene(int sceneIndex)
    {
        sceneIndex += SceneManager.GetActiveScene().buildIndex;
        SceneTransit sceneTransit = await LocalAssetLoader.Load<SceneTransit>(_transitToLevelReference);
        await sceneTransit.MakeTransition(sceneIndex);
        LocalAssetLoader.Unload(sceneTransit.gameObject);
    }
}