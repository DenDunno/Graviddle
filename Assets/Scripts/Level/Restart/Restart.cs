using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;


public class Restart : MonoBehaviour
{
    [SerializeField] private LoadingScreen _loadingScreen;
    [LightweightInject] private readonly CharacterStatesPresenter _characterStatesPresenter;

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
        var backstage = new Backstage(_loadingScreen, RestartObjects);

        await backstage.MakeTransition();

        _afterRestartComponents.ForEach(component => component.Restart());
    }


    private async UniTask RestartObjects()
    {
        _restartableComponents.ForEach(component => component.Restart());

        await UniTask.Delay(TimeSpan.FromSeconds(_restartTime));
    }
}