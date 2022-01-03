using System.Collections;
using UnityEngine;
using Zenject;


public class ArrowTrap : MonoBehaviour, IRestartableComponent
{
    [SerializeField] private float _startWaitTime = 0;
    [SerializeField] private float _coolDown = 2;
    [SerializeField] private ArrowSpawner _arrowSpawner = null;
    [Inject] private CharacterStatesPresenter _states = null;


    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_startWaitTime);

        while (Application.isPlaying)
        {
            _arrowSpawner.SpawnArrow();
            yield return new WaitForSeconds(_coolDown);
        }
    }


    private void OnEnable()
    {
        _states.DieState.CharacterDied += StopSpawning;
    }


    private void OnDisable()
    {
        _states.DieState.CharacterDied -= StopSpawning;
    }


    private void StopSpawning()
    {
        StopAllCoroutines();
    }


    void IRestartableComponent.Restart()
    {
        StartCoroutine(Start());
    }
}