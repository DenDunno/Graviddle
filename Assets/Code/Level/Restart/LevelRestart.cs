using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;


public class LevelRestart : ISubscriber
{
    private readonly RestartableComponents _restartableComponents;
    private readonly DieState _dieState;
    private const float _restartTime = 0.7f;


    public LevelRestart(RestartableComponents restartableComponents, DieState dieState)
    {
        _restartableComponents = restartableComponents;
        _dieState = dieState;
    }


    void ISubscriber.Subscribe()
    {
        _dieState.CharacterDied += MakeRestart;
    }
    

    void ISubscriber.Unsubscribe()
    {
        _dieState.CharacterDied -= MakeRestart;
    }


    private async void MakeRestart()
    {
        var deathScreen = await LocalAssetLoader.Load<LoadingScreen>("LevelRestart");
        var backstage = new Backstage(deathScreen, RestartObjects);

        await backstage.MakeTransition();

        _restartableComponents.AfterRestartComponents.RestartForEach();
        
        LocalAssetLoader.Unload(deathScreen.gameObject);
    }


    private async UniTask RestartObjects()
    {
        _restartableComponents.RestartComponents.RestartForEach();
        _restartableComponents.RestartTransforms.ResetTransformForEach();
        
        await UniTask.Delay(TimeSpan.FromSeconds(_restartTime));
    }
}