using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;


[RequireComponent(typeof(Backstage))]
public class Restart : MonoBehaviour
{
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter;
    private readonly float _restartTime = 0.7f;
    private Backstage _backstage;
    
    private IEnumerable<IRestartableComponent> _restartableComponents;
    private IEnumerable<IAfterRestartComponent> _afterRestartComponents;


    private void Start()
    {
        _backstage = GetComponent<Backstage>();
        MonoBehaviour[] allComponents = FindObjectsOfType<MonoBehaviour>(true);

        _restartableComponents = allComponents.OfType<IRestartableComponent>();
        _afterRestartComponents = allComponents.OfType<IAfterRestartComponent>();
    }


    private void OnEnable()
    {
        _characterStatesPresenter.DieState.CharacterDied += OnCharacterDied;
    }


    private void OnDisable()
    {
        _characterStatesPresenter.DieState.CharacterDied -= OnCharacterDied;
    }


    private void OnCharacterDied()
    {
        StartCoroutine(MakeRestart());
    }


    private IEnumerator MakeRestart()
    {
        yield return StartCoroutine(_backstage.MakeTransition(RestartObjects()));

        _afterRestartComponents.ForEach(component => component.Restart());
    }


    private IEnumerator RestartObjects()
    {
        _restartableComponents.ForEach(component => component.Restart());

        yield return new WaitForSeconds(_restartTime);
    }
}