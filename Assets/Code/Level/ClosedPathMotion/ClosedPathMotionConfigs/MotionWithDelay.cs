using UnityEngine;


public class MotionWithDelay : ClosedPathMotionType
{
    public override float Period => (1 + Speed * _waitTime) / Speed * 2;

    [SerializeField] private float _waitTime = 2f;
    private float _leftLimit;
    private float _offset; // y = speed * x + offset


    private void Start()
    {
        _leftLimit = (1 + Speed * _waitTime) / Speed;
        float x = _leftLimit + _waitTime;

        _offset = 1 + Speed * x;
    }


    public override float EvaluateMotionFunction(float time)
    {
        if (time >= 0 && time <= _waitTime)
        {
            return 0;
        }

        if (time >= _waitTime && time <= _leftLimit)
        {
            return Speed * (time - _waitTime);
        }

        if (time >= _leftLimit && time <= _leftLimit + _waitTime)
        {
            return 1;
        }

        return -Speed * time + _offset;
    }
}