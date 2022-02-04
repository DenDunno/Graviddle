using UnityEngine;


public class SceneTransitButtonClick : ButtonClick
{
    [SerializeField] private SceneTransit _sceneTransit;
    [SerializeField] private int _sceneIndex = 0;
    
    
    protected override async void OnButtonClick()
    {
        await _sceneTransit.MakeTransition(_sceneIndex);
    }
}
