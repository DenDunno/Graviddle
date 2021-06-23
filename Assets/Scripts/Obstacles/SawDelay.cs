using System.Collections;
using UnityEngine;

public class SawDelay : Saw , IRestartableObject
{
    [SerializeField]
    private float _coolDownTime = 2f;

    [SerializeField]
    private bool _waitAtStart = false;

    private Coroutine _coolDownCoroutine;


    protected override void Start()
    {
        base.Start();

        if (_waitAtStart == true)
            _coolDownCoroutine = StartCoroutine(Wait(_coolDownTime));
    }


    protected override void ChangeTarget()
    {
        base.ChangeTarget();
        _coolDownCoroutine = StartCoroutine(Wait(_coolDownTime));
    }


    private IEnumerator Wait(float waitTime)
    {
        _currentSpeed = 0;
        yield return new WaitForSeconds(waitTime);
        _currentSpeed = _maxSpeed;
    }


    public void Restart()
    {
        StopCoroutine(_coolDownCoroutine);

        transform.position = _startPosition;
        _start = transform.position;    
        _target = _startPosition + transform.right * _distance * (_goRight ? 1 : -1);

        StartCoroutine(Wait((_waitAtStart ? _coolDownTime : 0) + ScreenFade.TimeForRespawn));
    }
}
