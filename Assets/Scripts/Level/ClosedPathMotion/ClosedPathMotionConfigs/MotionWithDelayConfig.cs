using UnityEngine;


public class MotionWithDelayConfig : ClosedPathMotionConfig
{
    public override float Period => (1 + _speed * _waitTime) / _speed * 2;

    [SerializeField] private float _waitTime = 2f;
    private float _leftLimit;
    private float _b; // y = ax + b: a = speed , x = time


    private void Start()
    {
        _leftLimit = (1 + _speed * _waitTime) / _speed;
        float x = _leftLimit + _waitTime;

        _b = 1 + _speed * x;
    }


    public override float EvaluateMathFunction(float time)
    {
        if (time >= 0 && time <= _waitTime)
        {
            return 0;
        }

        else if (time >= _waitTime && time <= _leftLimit)
        {
            return _speed * (time - _waitTime);
        }

        else if (time >= _leftLimit && time <= _leftLimit + _waitTime)
        {
            return 1;
        }

        else
        {
            return -_speed * time + _b;
        }
    }
}