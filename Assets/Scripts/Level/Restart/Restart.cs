using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;


[RequireComponent(typeof(Backstage))]
public class Restart : MonoBehaviour
{
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;
    private readonly float _restartTime = 0.7f;
    private Backstage _backstage;
    
    private IEnumerable<IRestartableComponent> _restartableComponents = null;
    private IEnumerable<IAfterRestartComponent> _afterRestartComponents = null;


    private void Start()
    {
        _backstage = GetComponent<Backstage>();

        _restartableComponents = FindObjectsOfType<MonoBehaviour>().OfType<IRestartableComponent>();
        _afterRestartComponents = FindObjectsOfType<MonoBehaviour>().OfType<IAfterRestartComponent>();
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
        yield return StartCoroutine(_backstage.MakeFade(RestartObjects()));

        _afterRestartComponents.ForEach(component => component.Restart());
    }


    private IEnumerator RestartObjects()
    {
        _restartableComponents.ForEach(component => component.Restart());

        yield return new WaitForSeconds(_restartTime);
    }
}
