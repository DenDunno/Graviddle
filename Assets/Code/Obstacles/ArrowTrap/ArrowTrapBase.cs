using System.Collections;
using UnityEngine;

public abstract class ArrowTrapBase : MonoBehaviour, IRestart
{
    [SerializeField] private float _startWaitTime;
    [SerializeField] private float _coolDown = 2;

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

    void IRestart.Restart()
    {
        StopAllCoroutines();
        StartCoroutine(Shoot());
    }

    protected abstract IEnumerator OnShoot();
}