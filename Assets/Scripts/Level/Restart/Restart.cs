using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;


[RequireComponent(typeof(Backstage))]
public class Restart : MonoBehaviour
{
    [Inject] private readonly CharacterStates _characterStates = null;
    private readonly float _restartTime = 0.7f;
    private Backstage _backstage = null;

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
        _characterStates.DieState.CharacterDied += OnCharacterDied;
    }


    private void OnDisable()
    {
        _characterStates.DieState.CharacterDied -= OnCharacterDied;
    }


    private void OnCharacterDied()
    {
        StartCoroutine(MakeRestart());
    }


    private IEnumerator MakeRestart()
    {
        yield return StartCoroutine(_backstage.MakeFade(RestartObjects()));

        foreach (IAfterRestartComponent afterRestartComponent in _afterRestartComponents)
        {
            afterRestartComponent.Restart();
        }
    }


    private IEnumerator RestartObjects()
    {
        foreach(IRestartableComponent restartableObject in _restartableComponents)
        {
            restartableObject.Restart();
        }
        
        yield return new WaitForSeconds(_restartTime);
    }
}
