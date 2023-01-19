using System;
using Cysharp.Threading.Tasks;

public class LevelRestart : ISubscriber
{
    private readonly RestartableComponents _restartableComponents = new RestartableComponents();
    private readonly Action _restartEvent;
    private readonly DieState _dieState;
    private const float _restartTime = 0.7f;

    public LevelRestart(Action restartEvent, DieState dieState)
    {
        _restartEvent = restartEvent;
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
        Backstage backstage = new(deathScreen, RestartObjects);

        await backstage.MakeTransition();

        _restartableComponents.AfterRestartComponents.RestartForEach();
        
        LocalAssetLoader.Unload(deathScreen.gameObject);
    }

    private async UniTask RestartObjects()
    {
        _restartableComponents.RestartComponents.RestartForEach();
        _restartEvent();

        await UniTask.Delay(TimeSpan.FromSeconds(_restartTime));
    }
}