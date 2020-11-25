using System.Collections;
using UnityEngine;

public class SawDelay : Saw
{
    [SerializeField]
    private float _waitTime = 2f;
    protected override void ChangeTarget()
    {
        base.ChangeTarget();
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        float temp = _speed;
        _speed = 0;
        yield return new WaitForSeconds(_waitTime);
        _speed = temp;
    }
}
