using UnityEngine;
using UnityEngine.AddressableAssets;

public class SceneTransitButtonClick : ButtonClick
{
    [SerializeField] private int _sceneIndex;
    [SerializeField] private AssetReference _transitReference;

    protected override async void OnButtonClick()
    {
        var sceneTransit = await LocalAssetLoader.Load<SceneTransit>(_transitReference);
        
        await sceneTransit.MakeTransition(_sceneIndex);
        
        LocalAssetLoader.Unload(sceneTransit.gameObject);
    }
}
