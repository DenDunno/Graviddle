using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;


public class Restart : MonoBehaviour
{
    [LightweightInject] private readonly CharacterStatesPresenter _characterStatesPresenter;
    [SerializeField] private LocalAssetLoader _levelRestartLoader;

    private IEnumerable<IRestartableComponent> _restartableComponents;
    private IEnumerable<IAfterRestartComponent> _afterRestartComponents;
    private const float _restartTime = 0.7f;


    private void Start()
    {
        var allComponents = FindObjectsOfType<MonoBehaviour>(true);

        _restartableComponents = allComponents.OfType<IRestartableComponent>();
        _afterRestartComponents = allComponents.OfType<IAfterRestartComponent>();
    }


    private void OnEnable()
    {
        _characterStatesPresenter.DieState.CharacterDied += MakeRestart;
    }


    private void OnDisable()
    {
        _characterStatesPresenter.DieState.CharacterDied -= MakeRestart;
    }


    private async void  MakeRestart()
    {
        var deathScreen = await _levelRestartLoader.Load<LoadingScreen>();
        var backstage = new Backstage(deathScreen, RestartObjects);

        await backstage.MakeTransition();

        _afterRestartComponents.ForEach(component => component.Restart());
        
        _levelRestartLoader.Unload();
    }


    private async UniTask RestartObjects()
    {
        _restartableComponents.ForEach(component => component.Restart());

        await UniTask.Delay(TimeSpan.FromSeconds(_restartTime));
    }
}