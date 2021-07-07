using UnityEngine;


public class ClosedPathMotion : MonoBehaviour
{
    [SerializeField] private ClosedPathMotionCalculator _motionCalculator = null;
    [SerializeField] private Vector2 _targetPosition = Vector2.zero;

    private Vector2 _startPosition = Vector2.zero;


    private void Start()
    {
        _startPosition = transform.position;
        _motionCalculator.Init();
    }


    private void Update()
    {
        float lerp = _motionCalculator.EvaluateLerpPosition();
        transform.position = Vector2.Lerp(_startPosition, _targetPosition, lerp);
    }
}