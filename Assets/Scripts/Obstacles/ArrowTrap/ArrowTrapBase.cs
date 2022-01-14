using System.Collections;
using UnityEngine;
using Zenject;


public abstract class ArrowTrapBase : MonoBehaviour, IRestartableComponent
{
    [SerializeField] private float _startWaitTime;
    [SerializeField] private float _coolDown = 2;
    [Inject] private CharacterStatesPresenter _states;


    private void Start()
    {
        StartCoroutine(Shoot());
    }


    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(_startWaitTime);

        while (Application.isPlaying)
        {
            yield return StartCoroutine(OnShoot());
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
        StartCoroutine(Shoot());
    }


    protected abstract IEnumerator OnShoot();
}