using System.Collections;
using UnityEngine;


public class ArrowTrap : Obstacle , IRestartableObject
{
    [SerializeField] private float _coolDownTime = 2f;
    [SerializeField] private float _startWaitTime = 2f;

    private Arrow _arrow;
    private Vector2 _arrowPosition;

    private Coroutine _arrowSpawn;


    private void Start()
    {
        _arrow = Resources.Load<Arrow>("Prefabs/Obstacles/Arrow");
        _arrowPosition = transform.position - transform.up;

        _arrowSpawn = StartCoroutine(SpawnArrow());
    }


    private IEnumerator SpawnArrow()
    {
        yield return new WaitForSeconds(_startWaitTime);
        _arrow = Instantiate(_arrow, _arrowPosition, transform.rotation);

        while (true)
        {
            yield return new WaitForSeconds(_coolDownTime);
            _arrow.transform.position = _arrowPosition;
        }
    }


    public void Restart()
    {
        StopCoroutine(_arrowSpawn);
        _arrowSpawn = StartCoroutine(SpawnArrow());
    }
}
