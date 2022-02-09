using System.Collections;
using UnityEngine;


public abstract class ArrowTrapBase : MonoBehaviour, IRestart
{
    [SerializeField] private float _startWaitTime;
    [SerializeField] private float _coolDown = 2;
    [LightweightInject] private CharacterStatesPresenter _states;


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


    void IRestart.Restart()
    {
        StartCoroutine(Shoot());
    }


    protected abstract IEnumerator OnShoot();
}