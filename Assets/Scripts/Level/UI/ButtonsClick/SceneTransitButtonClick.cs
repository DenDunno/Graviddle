using UnityEngine;


public class SceneTransitButtonClick : ButtonClick
{
    [SerializeField] private LocalAssetLoader _transitLoader;
    [SerializeField] private int _sceneIndex;


    protected override async void OnButtonClick()
    {
        var sceneTransit = await _transitLoader.Load<SceneTransit>();
        
        await sceneTransit.MakeTransition(_sceneIndex);
        
        _transitLoader.Unload();
    }
}
