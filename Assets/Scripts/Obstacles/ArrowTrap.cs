using System.Collections;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField]
    private float _rechargeTime = 2f;

    [SerializeField]
    private float _startWaitTime = 2f;

    private Arrow _arrow;
    private Vector2 _arrowPosition;


    private void Start()
    {
        _arrow = Resources.Load<Arrow>("Prefabs/Obstacles/Arrow");
        _arrowPosition = transform.position - transform.up;

        StartCoroutine(ArrowSpawn());
    }


    private IEnumerator ArrowSpawn()
    {
        yield return new WaitForSeconds(_startWaitTime);
        _arrow = Instantiate(_arrow, _arrowPosition, transform.rotation);

        while (true)
        {
            yield return new WaitForSeconds(_rechargeTime);
            _arrow.transform.position = _arrowPosition;
        }
    }
}
